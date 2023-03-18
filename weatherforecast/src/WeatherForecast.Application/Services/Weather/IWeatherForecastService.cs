using WeatherForecast.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherForecast.Application.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherResponse> GetWeatherForecastByCity(string city);
        Task<WeatherResponse> GetWeatherForecastByZipCode(string zipCode);
    }
}
