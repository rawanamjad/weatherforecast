using WeatherForecast.Application.Models;

namespace WeatherForecast.Application.Services
{
    public interface IForecastService
    {
        Task<ForecastResponse> GetForecast(string city);
    }
}
