using WeatherForecast.Application.Services;
using WeatherForecast.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WeatherForecast.Application.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController
    {
        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forecast"></param>
        /// <returns></returns>
        [HttpGet("city/{cityName}")]
        public async Task<ActionResult> GetWeatherForecast([FromQuery]WeatherForecastRequest weatherForecastRequest)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (weatherForecastRequest != null && !string.IsNullOrEmpty(weatherForecastRequest.City))
            {
                var result = await _weatherForecastService.GetWeatherForecastByCity(weatherForecastRequest.City);

                //if (result != null && result.Forecasts.Count > 0)
                //    return Json(result);
                //else
                //    return NoContent();
                return null;
            }
            //else if (weatherForecastRequest != null && !string.IsNullOrEmpty(weatherForecastRequest.ZipCode))
            //{
            //    var result = await _weatherForecastService.GetWeatherForecastByZipCode(weatherForecastRequest.ZipCode);

            //    if (result != null && result.Forecasts.Count > 0)
            //        return Json(result);
            //    else
            //        return NoContent();
            //}

            return null;
        }

        // [HttpGet]
        // [Route("history")]
        // public ActionResult GetHistory()
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }


        //     var result = _weatherForecastService.GetHistory();

        //     if (result != null && result.Count > 0)
        //         return Json(result);

        //     return NoContent();
        // }
    }
}
