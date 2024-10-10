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
        response = Console.ReadLine().ToLower();
    } while (response == "yes");
}
https://www.wunderground.com/weather/us/%7Blocation%7D%22);
<Application x:Class="EwokWeatherRescueApp.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:EwokWeatherRescueApp"
             StartupUri="MainWindow.xaml">
    <Application.Resources>
        <Style TargetType="Button" x:Key="MainButtonStyle">
            <Setter Property="Background" Value="Red"/>
            <Setter Property="Foreground" Value="Black"/>
            <Setter Property="FontSize" Value="14"/>
            <Setter Property="Padding" Value="10,5"/>
            <Setter Property="Margin" Value="10"/>
            <Setter Property="BorderBrush" Value="Transparent"/>
        </Style>
        <Style TargetType="TextBlock" x:Key="MainTextStyle">
            <Setter Property="Foreground" Value="White"/>
            <Setter Property="FontSize" Value="14"/>
            <Setter Property="Margin" Value="5"/>
        </Style>
        <Style TargetType="TextBox" x:Key="MainTextBoxStyle">
            <Setter Property="Background" Value="#333333"/>
            <Setter Property="Foreground" Value="White"/>
            <Setter Property="FontSize" Value="14"/>
            <Setter Property="Padding" Value="5"/>
            <Setter Property="Margin" Value="5"/>
            <Setter Property="BorderBrush" Value="#A9A9A9"/>
        </Style>
    </Application.Resources>
</Application>
