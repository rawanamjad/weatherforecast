using WeatherForecast.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherForecast.Application.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecastResponse> GetWeatherForecastByCity(string city);
        //Task<WeatherForecastResponse> GetWeatherForecastByZipCode(string zipCode);
        //IReadOnlyCollection<WeatherHistory> GetHistory();
    }
}
