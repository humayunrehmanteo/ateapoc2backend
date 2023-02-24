namespace POC2.Domain.Dtos
{
    public class WeatherDto
    {
        public int CityId { get; set; }
        public string? CityName { get; set; }

        public string? CountryName { get; set; }
        public double? WindSpeed { get; set; }
        public string? WinSpeedUnit { get; set; }
        public double? TemperatureValue { get; set; }
        public string? TemperatureUnit { get; set; }
        public DateTime Dt { get; set; }
        public DateTime CreatedOn { get; set; }


    }
}
