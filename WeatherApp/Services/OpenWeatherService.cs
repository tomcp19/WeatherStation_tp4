using OpenWeatherAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Services
{
    class OpenWeatherService: ITemperatureService
    {
        private OpenWeatherProcessor owp;

        public TemperatureModel LastTemp;

        public OpenWeatherService(String apiKey)
        {
            owp = OpenWeatherProcessor.Instance;
            owp.ApiKey = apiKey;
            //Debug.WriteLine(" OWS..."); //ici ok.        
        }

        public async Task<TemperatureModel> GetTempAsync()
        {
            Debug.WriteLine("await...");

           LastTemp = new TemperatureModel();
            var OWATemp = await owp.GetCurrentWeatherAsync(); ;

            LastTemp.Temperature = OWATemp.Main.Temperature;
            
            //transfo date format long en DateTime
            //https://stackoverflow.com/questions/4964634/how-to-convert-long-type-datetime-to-datetime-with-correct-time-zone

            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            LastTemp.DateTime = start.AddSeconds(OWATemp.DateTime).ToLocalTime();
           // Debug.WriteLine("LastTemp Time + Temp : " + LastTemp.DateTime + " " + LastTemp.Temperature + " C"); //fonctionnel

            return LastTemp;
        }


    }
}
