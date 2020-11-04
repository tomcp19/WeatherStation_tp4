namespace WeatherApp.Converter
{
    public static class TemperatureConverter
    {
        /// <summary>
        /// Convert degree Celsius into Fahrenheit
        /// </summary>
        /// <param name="c">Degrees in Celsius</param>
        /// <returns>Degrees in Fahrenheit</returns>
        public static double CelsiusInFahrenheit(double c) => c * 9.0 / 5.0 + 32;

        /// <summary>
        /// Convert degree Fahrenheit into Celsius
        /// </summary>
        /// <param name="c">Degrees in Fahrenheit</param>
        /// <returns>Degrees in Celsius</returns>
        public static double FahrenheitInCelsius(double f) => (f - 32) * 5.0 / 9.0;
    }
}
