using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Application.DTOs
{
    public class WeatherResponse
    {
        public List<WeatherDto> List { get; set; }
    }
}
