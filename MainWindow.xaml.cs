using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EwokWeatherRescueApp.Models
{
    public class WeatherModel
    {
        public string Location { get; set; }
        public string Condition { get; set; }
        public string HighTemperature { get; set; }
        public string LowTemperature { get; set; }
        public string CurrentTemperature { get; set; }
    }

}
