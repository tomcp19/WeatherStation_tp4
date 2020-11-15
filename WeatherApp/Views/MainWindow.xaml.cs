using System.Windows;
using WeatherApp.ViewModels;
using WeatherApp.Models;
using System.Diagnostics;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TemperatureViewModel vm;

        public MainWindow()
        {
            InitializeComponent();

            /// TODO : Faire les appels de configuration ici ainsi que l'initialisation
            var APIKEY = AppConfiguration.GetValue("OWApiKey");
            //Debug.WriteLine("MainWindow API key" + APIKEY); //fonctionnel
            

            vm = new TemperatureViewModel();

            DataContext = vm;           
        }
    }
}
