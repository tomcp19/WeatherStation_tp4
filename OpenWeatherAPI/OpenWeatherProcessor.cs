using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace OpenWeatherAPI
{
    /// <summary>
    /// Classe permettant de faire des appels au service Open Weather
    /// Il faut avoir une clé API pour pouvoir l'utiliser
    /// </summary>
    public class OpenWeatherProcessor
    {
        /// <summary>
        /// Singleton
        /// </summary>
        private static readonly Lazy<OpenWeatherProcessor> lazy = new Lazy<OpenWeatherProcessor>(() => new OpenWeatherProcessor());

        public static OpenWeatherProcessor Instance { get { return lazy.Value; } }


        public string BaseURL { get; set; }
        public string EndPoint { get; set; }

        /// <summary>
        /// Longitude d'intérêt
        /// </summary>
        public string Longitude { get; set; } = "-72.7491"; // Shawinigan par défaut

        /// <summary>
        /// Latitude d'intérêt
        /// </summary>        
        public string Latitude { get; set; } = "46.5668";

        private string longUrl;

        public string ApiKey { get; set; } //= "9c5fc0b41ba43f61f3fc91aec078aaaa";

        private OpenWeatherProcessor()
        {
            BaseURL = $"https://api.openweathermap.org/data/2.5";
            EndPoint = $"/weather?";
        }

        
        /// <summary>
        /// Appel le endpoint One Call API
        /// </summary>
        /// <returns></returns>
        public async Task<OpenWeatherOneCallModel> GetOneCallAsync()
        {
            //try catch avec message
            //https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception?view=net-5.0
            //https://stackoverflow.com/questions/31398861/overriding-the-message-of-exception-in-c-sharp

            try
            {
                if (!String.IsNullOrEmpty(ApiKey))
                {
                    EndPoint = $"/onecall?";

                    /// Src : https://stackoverflow.com/a/14517976/503842
                    var uriBuilder = new UriBuilder($"{BaseURL}{EndPoint}");

                    var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                    query["lat"] = Latitude; // Shawinigan
                    query["lon"] = Longitude;
                    query["units"] = "metric";
                    query["appid"] = ApiKey;


                    uriBuilder.Query = query.ToString();
                    longUrl = uriBuilder.ToString();

                    return await doOneCall();
                }

                else
                {
                    throw new ArgumentException("GetOneCallAsync: La clé d'API ne doit pas être vide");
                }
            }

            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }


        }

        /// <summary>
        /// Appel le endpoint weather
        /// </summary>
        /// <returns></returns>
        public async Task<OWCurrentWeaterModel> GetCurrentWeatherAsync()
        {
            try
            {
                if (!String.IsNullOrEmpty(ApiKey))
                {

                    EndPoint = $"/weather?";

                    /// Src : https://stackoverflow.com/a/14517976/503842
                    var uriBuilder = new UriBuilder($"{BaseURL}{EndPoint}");

                    var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                    query["q"] = "Shawinigan"; // Shawinigan
                    query["units"] = "metric";
                    query["appid"] = ApiKey;

                    uriBuilder.Query = query.ToString();
                    longUrl = uriBuilder.ToString();

                    return await doCurrentWeatherCall();
                }

                else
               {
                    throw new ArgumentException("GetCurrentWeatherAsync: La clé d'API ne doit pas être vide");
                }
            }

            //https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception?view=net-5.0#examples
            //https://stackoverflow.com/questions/31398861/overriding-the-message-of-exception-in-c-sharp
            catch (Exception e)                    
            {
                Debug.WriteLine(e.Message);
                throw e;              
            }
        }

        private async Task<OpenWeatherOneCallModel> doOneCall()
        {

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(longUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    OpenWeatherOneCallModel result = await response.Content.ReadAsAsync<OpenWeatherOneCallModel>();
                    return result;
                }

                return null;
            }
        }

        private async Task<OWCurrentWeaterModel> doCurrentWeatherCall()
        {            
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(longUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    OWCurrentWeaterModel result = await response.Content.ReadAsAsync<OWCurrentWeaterModel>();
                    return result;
                }

                return null;

            }
        }
    }
}
