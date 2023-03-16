using System;
using System.Text.Json.Serialization;

namespace WeatherForecast.Application.DTOs
{
    public class WeatherDto
    {
        public MainDto Main { get; set; }
        public WindDto Wind { get; set; }
        [JsonPropertyName("dt_txt")]
        public DateTimeOffset ForecastDate { get; set; }
    }
}
