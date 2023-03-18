using WeatherForecast.Application.Models;
using System.Text.Json;


namespace WeatherForecast.Application.Services
{
    public class ForecastService : IForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiConfig _apiConfig;

        public ForecastService(HttpClient httpClient, ApiConfig apiConfig)
        {
            _httpClient = httpClient;
            _apiConfig = apiConfig;
        }

        public async Task<ForecastResponse> GetForecast(string city)
        {
            var response = await _httpClient.GetAsync($"{_apiConfig.ApiUrl}forecast?appid={_apiConfig.ApiKey}&q={city}&units=metric");
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                options.Converters.Add(new DateTimeOffsetJsonConverter());
                var forecastResponse = await JsonSerializer.DeserializeAsync<ForecastResponse>(responseStream, options);
                if (forecastResponse != null)
                    return forecastResponse;
                return new ForecastResponse();
            }
            else
            {
                return new ForecastResponse();
            }
        }
    }
}
