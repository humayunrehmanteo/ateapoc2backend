using POC2.Domain.Dtos;

namespace POC2.Domain.Interfaces
{
    public interface IWeatherRepository
    {
        Task<List<WeatherDto>> GetWeatherStats(int cityId);
        Task<List<WeatherDto>> GetMinTempRecords();
        Task<List<WeatherDto>> GetMaxWindSpeedRecords();
    }
}
