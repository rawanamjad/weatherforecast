using WeatherForecast.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherForecast.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="byCity"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("byCity")]
        public async Task<ActionResult> GetWeatherForecastByCity(string city)
        {
            
            if (!string.IsNullOrEmpty(city))
            {
                var result = await _weatherForecastService.GetWeatherForecastByCity(city);

                if (result != null)
                    return Ok(result);

            }
          
                   return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="byZipCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("byZipCode")]
        public async Task<ActionResult> GetWeatherForecastByZipCode(string zipCode)
        {

            if (!string.IsNullOrEmpty(zipCode))
            {
                var result = await _weatherForecastService.GetWeatherForecastByZipCode(zipCode);

                if (result != null)
                    return Ok(result);

            }

            return NoContent();
        }
    }
}
