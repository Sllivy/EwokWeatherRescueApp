using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EwokWeatherRescueApp.Models;

namespace EwokWeatherRescueApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WeatherViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new WeatherViewModel();
            DataContext = _viewModel;
        }

        private async void GetWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            var location = LocationInput.Text;
            if (!string.IsNullOrEmpty(location))
            {
                await _viewModel.GetWeatherDataAsync(location);
            }
        }

        private class WeatherViewModel
        {
            internal async Task GetWeatherDataAsync(string location)
            {
                throw new NotImplementedException();
            }
        }

    }
} 
