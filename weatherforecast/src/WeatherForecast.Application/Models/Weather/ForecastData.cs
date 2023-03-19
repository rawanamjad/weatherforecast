using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Application.Models
{
    public class ForecastData
    {
        public Clouds Clouds { get; set; }
        public Temperature Main { get; set; }
        public Wind Wind { get; set; }
        public CountryInfo Sys { get; set; }
        public List<Weather> Weather { get; set; }
        public int? Visibility { get; set; }
        public string dt_txt { get; set; }
        public int dt { get; set; }
    }
}
