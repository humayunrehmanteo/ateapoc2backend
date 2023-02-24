using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using POC2.Application.Common;
using POC2.Domain.Dtos;
using POC2.Domain.Interfaces;
using POC2.Infrastructure.Data;

namespace POC2.Infrastructure.Repositries
{
    public class WeatherDataRepository : IWeatherRepository
    {
        private readonly ApplicationConstants _applicationConstants;
        private readonly WeatherDbContext _context;
        public WeatherDataRepository(WeatherDbContext context, IOptions<ApplicationConstants> applicationConstants)
        {
            _context = context;
            _applicationConstants = applicationConstants.Value;
        }
        public async Task<List<WeatherDto>> GetWeatherStats(int cityId)
        {
            try
            {
                DateTime lastUpdatedTime = _context.WeatherData.OrderByDescending(x => x.CreatedOn).Select(x => x.CreatedOn).FirstOrDefault();
                var weatherList = await (from weather in _context.WeatherData
                                         join city in _context.Cities on weather.CityId equals city.Id
                                         join country in _context.Countries on city.CountryId equals country.Id
                                         where (weather.CreatedOn >= lastUpdatedTime.AddHours(-2) && weather.CityId == cityId)
                                         select new WeatherDto()
                                         {
                                             CityId = weather.CityId,
                                             CityName = city.Name,
                                             CountryName = country.Name,
                                             TemperatureValue = weather.TemperatureValue,
                                             TemperatureUnit = weather.TemperatureUnit,
                                             WindSpeed = weather.WindSpeedValue,
                                             WinSpeedUnit = weather.WindSpeedUnit,
                                             Dt = weather.LastUpdated,
                                             CreatedOn = weather.CreatedOn
                                         }).ToListAsync();


                return weatherList;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<List<WeatherDto>> GetMinTempRecords()
        {
            try
            {
                DateTime lastUpdatedTime = _context.WeatherData.OrderByDescending(x => x.CreatedOn).Select(x => x.CreatedOn).FirstOrDefault();

                var records = await (from weather in _context.WeatherData
                                     join city in _context.Cities on weather.CityId equals city.Id
                                     join country in _context.Countries on city.CountryId equals country.Id
                                     where weather.CreatedOn >= lastUpdatedTime.AddSeconds(-_applicationConstants.WindTemperatureStatsOffsetInSeconds)
                                     orderby weather.TemperatureValue
                                     select new WeatherDto
                                     {
                                         CityId = weather.CityId,
                                         CityName = city.Name,
                                         CountryName = country.Name,
                                         TemperatureValue = weather.TemperatureValue,
                                         TemperatureUnit = weather.TemperatureUnit,
                                         Dt = weather.LastUpdated,
                                         CreatedOn = weather.CreatedOn
                                     }).Take(_applicationConstants.MaxWeatherRecords).ToListAsync();


                return records;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<List<WeatherDto>> GetMaxWindSpeedRecords()
        {
            try
            {
                DateTime lastUpdatedTime = _context.WeatherData.OrderByDescending(x => x.CreatedOn).Select(x => x.CreatedOn).FirstOrDefault();

                var records = await (from weather in _context.WeatherData
                                     join city in _context.Cities on weather.CityId equals city.Id
                                     join country in _context.Countries on city.CountryId equals country.Id
                                     where weather.CreatedOn >= lastUpdatedTime.AddSeconds(-_applicationConstants.WindTemperatureStatsOffsetInSeconds)
                                     orderby weather.WindSpeedValue descending
                                     select new WeatherDto
                                     {
                                         CityId = weather.CityId,
                                         CityName = city.Name,
                                         CountryName = country.Name,
                                         WindSpeed = weather.WindSpeedValue,
                                         WinSpeedUnit = weather.WindSpeedUnit,
                                         Dt = weather.LastUpdated,
                                         CreatedOn = weather.CreatedOn
                                     }).Take(_applicationConstants.MaxWeatherRecords).ToListAsync();
                return records;

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
