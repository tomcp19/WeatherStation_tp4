using OpenWeatherAPI;
using System;
using System.Threading.Tasks;
using WeatherApp.ViewModels;
using Xunit;

namespace OpenWeatherAPITests
{
    public class OpenWeatherProcessorTests
    {
        TemperatureViewModel _sut = new TemperatureViewModel();
        OpenWeatherProcessor owp =  OpenWeatherProcessor.Instance;

        //Afficher le message de l’exception dans l’erreur que ApiKey est vide ou null.
        [Fact]
        public async Task GetOneCallAsync_IfApiKeyEmptyOrNull_ThrowArgumentException() 
        {
            //owp.ApiKey = "";
            owp.ApiKey = null;

            //enlever l'injection de l'api dans le mainWindow est plus efficace pour tester
            await Assert.ThrowsAsync<ArgumentException>(() => owp.GetOneCallAsync());
        }

        //Afficher le message de l’exception dans l’erreur que ApiKey est vide ou null.
        [Fact]
        public async Task GetCurrentWeatherAsync_IfApiKeyEmptyOrNull_ThrowArgumentException() 
        {
            owp.ApiKey = "";
            //owp.ApiKey = null;
            await Assert.ThrowsAsync<ArgumentException>(() => owp.GetCurrentWeatherAsync());
        }

        //Afficher le message de l’exception dans l’erreur que le client http n’est pas initialisé.
        [Fact]
        public async Task GetOneCallAsync_IfApiHelperNotInitialized_ThrowArgumentException() 
        {
            ApiHelper.ApiClient = null;
            await Assert.ThrowsAsync<ArgumentException>(() => owp.GetOneCallAsync());
        }
        
        //Afficher le message de l’exception dans l’erreur que le client http n’est pas initialisé
        [Fact]
        public async Task GetCurrentWeatherAsync_IfApiHelperNotInitialized_ThrowArgumentException() 
        {
            ApiHelper.ApiClient = null;
            await Assert.ThrowsAsync<ArgumentException>(() => owp.GetCurrentWeatherAsync());
        }

        


    }
}
