using WeatherForecast.Application.Models;
using System.Text.Json;

namespace WeatherForecast.Application.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiConfig _apiConfig;

        public WeatherForecastService(HttpClient httpClient, ApiConfig apiConfig)
        {
            _httpClient = httpClient;
            _apiConfig = apiConfig;
        }

        public async Task<WeatherResponse> GetWeatherForecastByCity(string city)
        {
            var response = await _httpClient.GetAsync($"{_apiConfig.ApiUrl}weather?appid={_apiConfig.ApiKey}&q={city}&units=metric");
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                options.Converters.Add(new DateTimeOffsetJsonConverter());
                var weatherResponse = await JsonSerializer.DeserializeAsync<WeatherResponse>(responseStream, options);
                if (weatherResponse != null)
                    return weatherResponse;
                return new WeatherResponse();
            }
            else
            {
                return new WeatherResponse();
            }
        }

        public async Task<WeatherResponse> GetWeatherForecastByZipCode(string zipCode)
        {
            var response = await _httpClient.GetAsync($"{_apiConfig.ApiUrl}weather?appid={_apiConfig.ApiKey}&q={zipCode}&units=metric");
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                options.Converters.Add(new DateTimeOffsetJsonConverter());
                var weatherResponse = await JsonSerializer.DeserializeAsync<WeatherResponse>(responseStream, options);
                if (weatherResponse != null) 
                    return weatherResponse;
                return new WeatherResponse();
            }
            else
            {
                return new WeatherResponse();
            }
        }
    }
}
