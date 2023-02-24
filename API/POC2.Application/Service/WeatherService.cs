using POC2.Application.Dtos;
using POC2.Application.Interfaces;
using POC2.Domain.Interfaces;

namespace POC2.Application.Service
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;
        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<List<WindRecords>> GetMaxWindSpeedRecords()
        {
            try
            {
                var maxWindSpeedRecords = await _weatherRepository.GetMaxWindSpeedRecords();
                List<WindRecords> windRecords = new();

                foreach (var item in maxWindSpeedRecords)
                {
                    windRecords.Add(new WindRecords()
                    {
                        cityId = item.CityId,
                        cityName = item.CityName,
                        countryName = item.CountryName,
                        windSpeed = item.WindSpeed,
                        y = item.WindSpeed,
                        windSpeedUnit = item.WinSpeedUnit,
                        dt = item.Dt,
                        createdOn = item.CreatedOn
                    });

                }
                return windRecords;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<TemperatureRecords>> GetMinTempRecords()
        {
            try
            {
                var minTempRecords = await _weatherRepository.GetMinTempRecords();

                List<TemperatureRecords> tempRecords = new();

                foreach (var item in minTempRecords)
                {
                    tempRecords.Add(new TemperatureRecords()
                    {
                        CityId = item.CityId,
                        CityName = item.CityName,
                        CountryName = item.CountryName,
                        Temperature = item.TemperatureValue,
                        Y = item.TemperatureValue,
                        TemperatureUnit = item.TemperatureUnit,
                        Dt = item.Dt,
                        CreatedOn = item.CreatedOn
                    });

                }
                return tempRecords;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<WeatherStatsResponse> GetWeatherStats(int id)
        {
            try
            {
                var weatherStats = await _weatherRepository.GetWeatherStats(id);

                WeatherStatsResponse weatherStatsResponse = new()
                {
                    Temperature = new List<Temperatures>(),
                    WindSpeed = new List<WindSpeeds>()
                };


                foreach (var item in weatherStats)
                {
                    weatherStatsResponse.City = item.CityName;
                    weatherStatsResponse.Country = item.CountryName;
                    weatherStatsResponse.Temperature.Add( new Temperatures()
                    {
                        CityId = item.CityId,
                        Temperature = item.TemperatureValue,
                        Dt = item.Dt,
                        CreatedOn = item.CreatedOn,
                        TemperatureUnit = item.TemperatureUnit
                    });

                 weatherStatsResponse.WindSpeed.Add(
                    new WindSpeeds()
                    {
                        CityId = item.CityId,
                        WindSpeed = item.WindSpeed,
                        Dt = item.Dt,
                        CreatedOn = item.CreatedOn,
                        WindSpeedUnit = item.WinSpeedUnit
                    });

                }
                return weatherStatsResponse;
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
