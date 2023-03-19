# Weather Forecast ASP .NET Core 6 and Vue web application
## Introduction
This is an application that allows users to get weather forecast information based on a city name or zip code. The weather information includes:
* Temperature
* Humidity
* Pressure
* Sunset time
* Sunrise time
* Cloudiness
* Wind speed etc

It also displays five days forecast starting from today's date including weather, temperature and humidity.
It also maintains the history of searched city and it's respective temperature and humidity percentage.

## Setup
* Use visual studio to run WeatherForecast.Application project. Run **dotnet restore** to restore nuget packages.
* Start the WeatherForecast.Application.cs proj. It displays an empty backend html file with 404 error but the project is running fine
* Copy Path of WeatherForecast.Presentation and change directory. Run the command **cd <copied path>** in visual code terminal.
* Run **npm install**
* Run **npx vue-cli-service build**
* Run **npx vue-cli-service serve** to start the Vue.js development server
* The frontend application runs on http://localhost:8080/ port
* The backend application runs on http://localhost:7001/ port
![image](https://user-images.githubusercontent.com/52230299/226194948-52b0a7d9-c160-4678-80bf-1118af53b1d6.png)

## Coding Practices Used
* MVC
* SOLID Principles
* Seperation of concerns
* OOP implementation
* Dependency Injection for ApiConfig, HttpClient and Services
* Axios for calling backend endpoints
* Async/Await
* Exception handling
* Env files for global variables
* Clean Code with comments
* Git for version control

## Conclusion
This application is a good example of how to build a modern, scalable, and maintainable web application using ASP.NET Core 6, Vue.js, and other modern web technologies. By following SOLID and OOP principles, the code is easy to understand, extend and test.
