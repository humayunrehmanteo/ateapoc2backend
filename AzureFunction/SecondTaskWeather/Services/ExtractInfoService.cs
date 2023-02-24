using SecondTaskWeather.Domain;
using SecondTaskWeather.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SecondTaskWeather.Services
{
    internal class ExtractInfoService : IExtractInfoService
    {
        private readonly HttpClient _httpClient;
        private readonly IDataService _dataService;
        public ExtractInfoService(IHttpClientFactory httpClientFactory, IDataService dataService)
        {
            _httpClient = httpClientFactory.CreateClient();
            _dataService = dataService;
        }
        public async Task<bool> GetStoreWeatherDataAsync()
        {
            if (_httpClient is null) throw new Exception(ServiceMessages.HttpClientNullObject.Value);

            try
            {
                List<City> cities = _dataService.GetCities();
                List<WeatherData> weatherData = new List<WeatherData>();

                foreach (City city in cities)
                {
                    string WeatherAPIUri = GetWeatherAPIUrl(FuncConfigurations.WeatherDataURL.Value, city);
                    var response = await _httpClient.GetAsync(WeatherAPIUri);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var payloadJsonString = await response.Content.ReadAsStringAsync();

                        var result = JsonConvert.DeserializeObject<WeatherDataModel>(payloadJsonString);

                        weatherData.Add(new WeatherData {
                            CityId = city.Id,
                            CreatedOn = DateTime.UtcNow,
                            TemperatureValue = result.Main.Temp,
                            TemperatureUnit = "Celsius",
                            WindSpeedValue = result.Wind.Speed,
                            WindSpeedUnit = "m/s",
                            Clouds = result.Clouds.All,
                            LastUpdated = UnixTimeStampToDateTime(result.Dt)
                        });
                    }
                }

                if (weatherData.Count > 0) 
                    return await _dataService.DumpWeatherDataAsync(weatherData);

                return false;
            }
            catch
            {
                throw;
            }
        }

        private string GetWeatherAPIUrl(string weatherAPIUri, City city)
        {
            return weatherAPIUri.Replace("[LAT]", city.Latitude.ToString()).Replace("[LONG]", city.Latitude.ToString());
        }
        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
