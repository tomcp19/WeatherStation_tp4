using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows;

namespace WeatherApp.Models
{
    public static class AppConfiguration
    {
        private static IConfiguration configuration;

        public static String GetValue(String key)
        {  //Retourne la valeur de la clé indiquée en parametre, celle du membre configuration, si config null, appellle initConfig

            if (configuration == null)
            {
                initConfig();
            }
            
            return configuration.GetSection("Secrets")[key];  //configuration.GetSection("Secrets")["OWApiKey"];
        }
        private static void initConfig()
        { //Initialise le membre configuration avec un fichier appsetting.json et un fichier secret

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            builder.AddUserSecrets<MainWindow>();            //AddUserSecrets<T>
            configuration = builder.Build();
            var API = configuration.GetSection("Secrets")["OWApiKey"];             //configuration["OWApiKey"];
            Debug.WriteLine("Secrets API: " + API);
        }

    }
}
