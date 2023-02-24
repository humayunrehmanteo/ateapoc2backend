using System;

namespace SecondTaskWeather.Domain
{
    public class WeatherData
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public decimal TemperatureValue { get; set; }
        public string TemperatureUnit { get; set; }
        public decimal WindSpeedValue { get; set; }
        public string WindSpeedUnit { get; set; }
        public int Clouds { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
