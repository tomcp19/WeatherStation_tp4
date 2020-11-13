using OpenWeatherAPI;
using OWApi_QuickTest.ViewModels;
using System.Windows;

namespace OWApi_QuickTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new OpenWeatherViewModel();

            ApiHelper.InitializeClient();
        }
    }
}
