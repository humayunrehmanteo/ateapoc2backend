using POC2.Application.Dtos;

namespace POC2.Application.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherStatsResponse> GetWeatherStats(int id);
        Task<List<TemperatureRecords>> GetMinTempRecords();
        Task<List<WindRecords>> GetMaxWindSpeedRecords();
    }
}
