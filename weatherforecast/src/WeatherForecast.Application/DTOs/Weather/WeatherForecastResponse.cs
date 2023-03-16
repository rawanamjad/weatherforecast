using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Application.DTOs
{
    public class WeatherForecastResponse
    {
        public IReadOnlyCollection<ForecastDto> Forecasts { get; set; }
    }
}
