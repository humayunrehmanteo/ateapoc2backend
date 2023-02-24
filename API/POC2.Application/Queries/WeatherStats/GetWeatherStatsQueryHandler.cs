using MediatR;
using Microsoft.Extensions.Logging;
using POC2.Application.Dtos;
using POC2.Application.Interfaces;
using POC2.Application.Queries.MinimumTemperature;

namespace POC2.Application.Queries.WeatherStats
{
    public class GetWeatherStatsQueryHandler : IRequestHandler<GetWeatherStatsQuery, WeatherStatsResponse>
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<GetWeatherStatsQueryHandler> _logger;
        public GetWeatherStatsQueryHandler(IWeatherService weatherService, ILogger<GetWeatherStatsQueryHandler> logger)
        {
            _weatherService = weatherService;
            _logger = logger;   
        }
        public async Task<WeatherStatsResponse> Handle(GetWeatherStatsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var weatherStats = await _weatherService.GetWeatherStats(request.CityId);
                weatherStats.Success = true;
                weatherStats.Message = "Success";
                return weatherStats;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new WeatherStatsResponse()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
