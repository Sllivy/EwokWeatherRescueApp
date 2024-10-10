using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

internal class WeatherViewModel : INotifyPropertyChanged
{
    private WeatherModel _weather;
    public WeatherModel Weather
    {
        get { return _weather; }
        set
        {
            _weather = value;
            OnPropertyChanged("Weather");
        }
    }

    public WeatherViewModel()
    {
        Weather = new WeatherModel();
    }

    public async Task GetWeatherDataAsync(string location)
    {
        var client = new HttpClient();
        var response = await client.GetStringAsync($"https://www.wunderground.com/weather/us/%7Blocation%7D");
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(response);

        // Update selectors based on the actual HTML structure
        Weather.HighTemperature = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='high']").InnerText;
        Weather.LowTemperature = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='low']").InnerText;
        Weather.CurrentTemperature = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='current']").InnerText;
        Weather.Condition = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='condition']").InnerText;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
public async Task GetMultipleWeatherDataAsync()
{
    string response;
    do
    {
        // Get user input, fetch weather, and display
        // Implement input logic or UI for multiple searches
        response = Console.ReadLine().ToLower();
    } while (response == "yes");
}
https://www.wunderground.com/weather/us/%7Blocation%7D%22);
