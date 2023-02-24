using Newtonsoft.Json;

namespace SecondTaskWeather.Domain
{

    // API Response mapping Model
    public class WeatherDataModel
    {
        [JsonProperty("main")]
        public MainInfo Main { get; set; }

        [JsonProperty("wind")]
        public WindInfo Wind { get; set; }

        [JsonProperty("clouds")]
        public CloudsInfo Clouds { get; set; }
        [JsonProperty("dt")]
        public int Dt { get; set; }
    }
    public class MainInfo 
    {
        [JsonProperty("Temp")]
        public decimal Temp { get; set; }
    }
    public class WindInfo
    {
        [JsonProperty("speed")]
        public decimal Speed { get; set; }
    }
    public class CloudsInfo
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
