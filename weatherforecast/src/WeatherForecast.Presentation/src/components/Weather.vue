<template>
  <div class="container-fluid mt-5">
    <div class="row">
      <div class="col-md-6 offset-md-3">
        <h1 class="text-center mb-4">Weather Forecast</h1>
        <div class="form-group">
          <input type="text" class="form-control" v-model="location" placeholder="Enter city name or zip code" />
        </div>
        <div class="text-center">
          <button class="btn btn-primary mb-3" @click="getWeather">Get Weather</button>
        </div>
        <div v-if="weather">
          debugger;
          <h2 class="mb-4">{{ weather.name }}, {{ weather.sys.country }}</h2>
          <div class="row mb-4">
            <div class="col-md-4">
              <p><strong>Temperature:</strong> {{ weather.main.temp }}&deg;C</p>
              <p><strong>Humidity:</strong> {{ weather.main.humidity }}%</p>
              <p><strong>Wind Speed:</strong> {{ weather.wind.speed }} m/s</p>
            </div>
            <div class="col-md-4">
              <p><strong>Weather:</strong> {{ weather.weather[0].description }}</p>
              <p><strong>Cloudiness:</strong> {{ weather.clouds.all }}%</p>
              <p><strong>Sunrise:</strong> {{ getFormattedTime(weather.sys.sunrise) }}</p>
            </div>
            <div class="col-md-4">
              <p><strong>Pressure:</strong> {{ weather.main.pressure }} hPa</p>
              <p><strong>Visibility:</strong> {{ weather.visibility }} m</p>
              <p><strong>Sunset:</strong> {{ getFormattedTime(weather.sys.sunset) }}</p>
            </div>
          </div>
        </div>
        <div v-if="forecast">
          <h2 class="mb-4">Weather Forecast for the Next 5 Days</h2>
          <div class="table-responsive">
            <table class="table table-striped table-bordered">
              <thead>
                <tr>
                  <th>Date</th>
                  <th>Weather</th>
                  <th>Temperature</th>
                  <th>Humidity</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(day, index) in forecast" :key="index">
                  <td>{{ getFormattedDate(day.dt) }}</td>
                  <td>
                    <img :src="'https://openweathermap.org/img/wn/'+day.weather[0].icon+'.png'" :alt="day.weather[0].description" />
                    {{ day.weather[0].description }}
                  </td>
                  <td>{{ day.main.temp }}&deg;C</td>
                  <td>{{ day.main.humidity }}%</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div v-if="history.length">
          <h2 class="mb-4">Search History</h2>
          <ul class="list-group">
            <li class="list-group-item mb-3" v-for="(item, index) in history" :key="index">
              <p>{{ item.city }} - {{ item.temp }}&deg;C - {{ item.humidity }}%</p>
              </li>
            </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import WeatherService from "../services/weather.service";
export default {
  name: "Weather",
  data() {
    return {
      location: "",
      weather: null,
      forecast: null,
      history: [],
    };
  },
  mounted() {
    if (localStorage.getItem("history")) {
      this.history = JSON.parse(localStorage.getItem("history"));
    }
  },
  methods: {
    async getWeather() {
      try {
        const response = await WeatherService.getWeather(this.location);
        this.weather = response;
        this.location = "";
        this.saveSearchHistory();
        this.getForecast();
      } catch (error) {
        this.weather = null;
        console.log(error);
      }
    },
    async getForecast() {
      try {
        const response = await WeatherService.getForecast(this.weather.name);
        this.forecast = response.list.filter((item) => item.dt_txt.includes("12:00:00"));
      } catch (error) {
        this.forecast = null;
        console.log(error);
      }
    },
    getFormattedTime(timestamp) {
      const date = new Date(timestamp * 1000);
      const hours = date.getHours();
      const minutes = "0" + date.getMinutes();
      return hours + ":" + minutes.substr(-2);
    },
    getFormattedDate(timestamp) {
      const date = new Date(timestamp * 1000);
      const options = { weekday: "short", month: "short", day: "numeric" };
      return date.toLocaleDateString("en-US", options);
    },
    saveSearchHistory() {
      const { name, main } = this.weather;
      const { temp, humidity } = main;
      const search = { city: name, temp, humidity };
      this.history.push(search);
      localStorage.setItem("history", JSON.stringify(this.history));
    },
  },
};
</script>

<style>
/* Custom CSS Styles */

.btn-primary {
  background-color: #007bff;
  border-color: #007bff;
}

.btn-primary:hover {
  background-color: #0069d9;
  border-color: #0062cc;
}

.table-responsive {
  max-height: 400px;
  overflow-y: scroll;
}

.list-group-item {
  background-color: #f8f9fa;
  border-color: #f8f9fa;
}

.list-group-item:hover {
  background-color: #e2e6ea;
  cursor: pointer;
}
</style>

