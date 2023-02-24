using MediatR;
using Microsoft.AspNetCore.Mvc;
using POC2.Application.Queries.MaximumWindSpeed;
using POC2.Application.Queries.MinimumTemperature;
using POC2.Application.Queries.WeatherStats;

namespace POC2.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("weatherStats")]
        public async Task<IActionResult> GetWeatherStats([FromQuery] GetWeatherStatsQuery request)
        {

            var resp = await _mediator.Send(request);

            return Ok(resp);
        }
        [HttpGet]
        [Route("minTempRecord")]
        public async Task<IActionResult> GetMinTemp()
        {

            var resp = await _mediator.Send(new GetMinTemperatureQuery());

            return Ok(resp);
        }
        [HttpGet]
        [Route("highestWindSpeedRecord")]
        public async Task<IActionResult> GetHighestWindSpeed()
        {

            var resp = await _mediator.Send(new GetMaxWindSpeedQuery());

            return Ok(resp);
        }

    }
}
