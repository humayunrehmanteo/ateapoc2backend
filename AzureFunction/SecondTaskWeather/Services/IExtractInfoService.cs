using System.Threading.Tasks;

namespace SecondTaskWeather.Services
{
    public interface IExtractInfoService
    {
        Task<bool> GetStoreWeatherDataAsync();
    }
}
