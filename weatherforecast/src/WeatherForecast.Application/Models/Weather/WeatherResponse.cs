
namespace WeatherForecast.Application.Models
{
    public class WeatherResponse
    {
        public Clouds Clouds { get; set; }
        public Temperature Main { get; set; }
        public Wind Wind { get; set; }
        public string? Name { get; set; }
        public int? Visibility { get; set; }
        public CountryInfo Sys { get; set; }
        public List<Weather> Weather { get; set; }

    }
}
