using SecondTaskWeather.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecondTaskWeather.Infrastructure
{
    public interface IDataService
    {
        List<City> GetCities();
        Task<bool> DumpWeatherDataAsync(List<WeatherData> weatherData);
    }
}
