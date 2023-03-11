const baseUrl = 'https://api.openweathermap.org/data/2.5/';
class WeatherService {
  constructor(apiKey) {
    this.apiKey = apiKey;
  }

  async getWeather(city) {
    const params = new URLSearchParams({
      q: city,
      appid: this.apiKey,
      units: "metric"
    });
    const response = await fetch(`${baseUrl}weather?${params}`);
    if (!response.ok) {
      throw new Error("Could not fetch weather data");
    }
    const data = await response.json();
    return data;
  }

  async getForecast(city) {
    const params = new URLSearchParams({
      q: city,
      appid: this.apiKey,
      units: "metric"
    });
    const response = await fetch(`${baseUrl}forecast?${params}`);
    if (!response.ok) {
      throw new Error("Could not fetch weather data");
    }
    const data = await response.json();
    return data;
  }
}

export default new WeatherService('fcadd28326c90c3262054e0e6ca599cd');