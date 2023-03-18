using WeatherForecast.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherForecast.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForecastController : ControllerBase
    {
        private readonly IForecastService _forecastService;
        public ForecastController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="byCity"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("byCity")]
        public async Task<ActionResult> GetForecast(string city)
        {

            if (!string.IsNullOrEmpty(city))
            {
                var result = await _forecastService.GetForecast(city);

                if (result != null)
                    return Ok(result);
            }
            return NoContent();
        }
    }
}
