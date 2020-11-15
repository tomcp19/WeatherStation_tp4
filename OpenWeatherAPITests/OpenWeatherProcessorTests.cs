using System;
using WeatherApp.ViewModels;

namespace OpenWeatherAPITests
{
    public class OpenWeatherProcessorTests
    {
        TemperatureViewModel _sut = new TemperatureViewModel();
        //Afficher le message de l’exception dans l’erreur que ApiKey est vide ou null.
        public void GetOneCallAsync_IfApiKeyEmptyOrNull_ThrowArgumentException() 
        { 
           // _sut.GetOneCall
        }

        //Afficher le message de l’exception dans l’erreur que ApiKey est vide ou null.
        public void GetCurrentWeatherAsync_IfApiKeyEmptyOrNull_ThrowArgumentException() 
        { 

        }

        //Afficher le message de l’exception dans l’erreur que le client http n’est pas initialisé.
        public void GetOneCallAsync_IfApiHelperNotInitialized_ThrowArgumentException() 
        { 

        }

        //Afficher le message de l’exception dans l’erreur que le client http n’est pas initialisé
        public void GetCurrentWeatherAsync_IfApiHelperNotInitialized_ThrowArgumentException() 
        { 

        }




    }
}
