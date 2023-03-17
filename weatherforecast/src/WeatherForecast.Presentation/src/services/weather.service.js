import axios from "axios";
class WeatherService {
 
  async getWeatherByCity(city) {
     const response = await axios.get(process.env.VUE_APP_WEATHER_PROXY + "/byCity" + "?city=" + city);
     if (response.status != 200) {
      throw new Error("Could not fetch weather data");
     }
    return response.data;
  }
  
  async getWeatherByZipCode(zipCode) {
    const response = await axios.get(process.env.VUE_APP_WEATHER_PROXY + "/byZipCode" + "?zipCode=" + zipCode);
    if (response.status != 200) {
    throw new Error("Could not fetch weather data");
   }
   return response.data;
  }

  async getWeather(searchText) {
    let weatherData = null;
    try {
      // Try to get weather data by city name
      weatherData = await this.getWeatherByCity(searchText);
    } catch (error) {
      console.log(`Error getting weather data by city name: ${error.message}`);
  
      try {
        // Try to get weather data by zip code
        weatherData = await this.getWeatherByZipCode(searchText);
      } catch (error) {
        console.log(`Error getting weather data by zip code: ${error.message}`);
      }
    }
    
  return weatherData;
}
  async getForecast(city) {
    const response = await axios.get(process.env.VUE_APP_FORECAST_PROXY + "/byCity" + "?city=" + city);
    if (!response.data) {
      throw new Error("Could not fetch forecast data");
    }
    debugger;
    return response.data;
  }
}

export default new WeatherService();