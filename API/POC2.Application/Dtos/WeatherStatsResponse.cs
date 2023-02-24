namespace POC2.Application.Dtos
{
    public class WeatherStatsResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public List<Temperatures>? Temperature { get; set; }
        public List<WindSpeeds>? WindSpeed { get; set; }

    }
    public class Temperatures
    {
        public int CityId { get; set; }
        public double? Temperature { get; set; }
        public string? TemperatureUnit { get; set; }
        
        public DateTime Dt { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class WindSpeeds
    {
        public int CityId { get; set; }
        public double? WindSpeed { get; set; }
        public string? WindSpeedUnit { get; set; }
        
        public DateTime Dt { get; set; }
        public DateTime CreatedOn { get; set; }
    }

}
