using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Application.Models
{
    public class CountryInfo
    {
        public string? Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
}
