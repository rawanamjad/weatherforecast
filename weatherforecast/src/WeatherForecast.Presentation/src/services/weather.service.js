const baseUrl = 'https://api.openweathermap.org/data/2.5/';
const apiUrl  = 'https://localhost:7001/api/weather'
import axios from "axios";
class WeatherService {
  constructor(apiKey) {
    this.apiKey = apiKey;
  }

  async getWeatherByCity(city) {
    debugger;
    // const params = new URLSearchParams({
    //  q: city,
    //  appid: this.apiKey,
    //  units: "metric"
    // });
    // const response = await fetch(`${baseUrl}weather?${params}`);
    // if (!response.ok) {
    //  throw new Error("Could not fetch weather data");
    // }
    // const data = await response.json();
    // return data;
     //return axios.get(apiUrl + "?city=" + city);
     const response = await axios.get(apiUrl + "/byCity" + "?city=" + city);
    //  if (!response.ok) {
    //   debugger;
    //  throw new Error("Could not fetch weather data");
    // }
    return response.data;
  }
  
  static async getWeatherByZipCode(zipCode) {
    const params = new URLSearchParams({
      zip: zipCode,
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

  async getWeather(searchText) {
    let weatherData = null;
    try {
      // Try to get weather data by city name
      weatherData = await this.getWeatherByCity(searchText);
    } catch (error) {
      console.log(`Error getting weather data by city name: ${error.message}`);
  
      // try {
      //   // Try to get weather data by zip code
      //   weatherData = await this.getWeatherByZipCode(searchText);
      // } catch (error) {
      //   console.log(`Error getting weather data by zip code: ${error.message}`);
      // }
    }
    
  return weatherData;
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