using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecondTaskWeather.Domain;


namespace SecondTaskWeather.Infrastructure
{
    internal class DataService : IDataService
    {
        private readonly WeatherDBContext _weatherDBContext;
        public DataService(WeatherDBContext weatherDBContext)
        {
            _weatherDBContext = weatherDBContext;
        }
        public async Task<bool> DumpWeatherDataAsync(List<WeatherData> weatherData)
        {
            await _weatherDBContext.WeatherData.AddRangeAsync(weatherData);
            return (await _weatherDBContext.SaveChangesAsync()) > 0;
        }

        public List<City> GetCities()
        {
            return _weatherDBContext.Cities.ToList();
        }
    }
}
