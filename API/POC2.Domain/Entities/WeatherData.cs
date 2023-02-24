namespace POC2.Domain.Entities
{
    public class WeatherData
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public double TemperatureValue { get; set; }
        public string? TemperatureUnit { get; set; }
        public double? WindSpeedValue { get; set; }
        public string? WindSpeedUnit { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
