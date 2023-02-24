namespace POC2.Application.Dtos
{
    public class MaxWindSpeedRecords
    {
        public bool success { get; set; }
        public string? message { get; set; }
        public List<WindRecords>? maxWindSpeedRecords { get; set; }

    }
    public class WindRecords
    {
        public int cityId { get; set; }
        public string? cityName { get; set; }
        public string? countryName { get; set; }
        public double? windSpeed { get; set; }
        public double? y { get; set; } //for plotting y axis on FE
        public string? windSpeedUnit { get; set; }
        public DateTime? dt { get; set; }

        public DateTime createdOn { get; set; }

    }
}
