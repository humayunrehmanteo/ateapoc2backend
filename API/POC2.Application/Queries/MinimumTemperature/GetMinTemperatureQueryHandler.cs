using MediatR;
using Microsoft.Extensions.Logging;
using POC2.Application.Dtos;
using POC2.Application.Interfaces;
using POC2.Application.Queries.MaximumWindSpeed;

namespace POC2.Application.Queries.MinimumTemperature
{
    public class GetMinTemperatureQueryHandler : IRequestHandler<GetMinTemperatureQuery, MinTempRecords>
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<GetMinTemperatureQueryHandler> _logger;
        public GetMinTemperatureQueryHandler(IWeatherService weatherService, ILogger<GetMinTemperatureQueryHandler> logger)
        {
            _weatherService = weatherService;
            _logger = logger;   
        }
        public async Task<MinTempRecords> Handle(GetMinTemperatureQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tempRecords = await _weatherService.GetMinTempRecords();
                if (tempRecords.Count > 0)
                {
                    List<TemperatureRecords> tempList = new List<TemperatureRecords>();
                    tempList.AddRange(tempRecords);

                    return new MinTempRecords()
                    {
                        Success = true,
                        Message = "Success",
                        TemperatureRecords = tempList
                    };
                }
                return new MinTempRecords()
                {
                    Success = true,
                    Message = "No temperature records found"
                };


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new MinTempRecords()
                {
                    Success = true,
                    Message = ex.Message,
                };
            }
        }

    }
}


