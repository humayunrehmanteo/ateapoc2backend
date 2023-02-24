using MediatR;
using Microsoft.Extensions.Logging;
using POC2.Application.Dtos;
using POC2.Application.Interfaces;

namespace POC2.Application.Queries.MaximumWindSpeed
{
    public class GetMaxWindSpeedQueryHandler : IRequestHandler<GetMaxWindSpeedQuery, MaxWindSpeedRecords>
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<GetMaxWindSpeedQueryHandler> _logger;

        public GetMaxWindSpeedQueryHandler(IWeatherService weatherService, ILogger<GetMaxWindSpeedQueryHandler> logger)
        {
            _weatherService = weatherService;
            _logger = logger;   
        }

        public async Task<MaxWindSpeedRecords> Handle(GetMaxWindSpeedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var windRecords = await _weatherService.GetMaxWindSpeedRecords();
                if (windRecords.Count > 0)
                {
                    List<WindRecords> windRecord = new List<WindRecords>();
                    windRecord.AddRange(windRecords);

                    return new MaxWindSpeedRecords()
                    {
                        success = true,
                        message = "Success",
                        maxWindSpeedRecords = windRecord
                    };
                }
                return new MaxWindSpeedRecords()
                {
                    success = true,
                    message = "No wind records found"
                };


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new MaxWindSpeedRecords()
                {
                    success = true,
                    message = ex.Message,
                };
            }
        }
    }
}
