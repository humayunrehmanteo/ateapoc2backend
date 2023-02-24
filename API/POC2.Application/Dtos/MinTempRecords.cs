namespace POC2.Application.Dtos
{
    public class MinTempRecords
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<TemperatureRecords>? TemperatureRecords { get; set; }

    }
    public class TemperatureRecords
    {
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public string? CountryName { get; set; }
        public double? Temperature { get; set; }
        public double? Y { get; set; } //for plotting y axis on FE
        public string? TemperatureUnit { get; set; }
        public DateTime Dt { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
