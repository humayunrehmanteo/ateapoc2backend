using System;

namespace SecondTaskWeather
{
    public class FuncConfigurations
    {
        private FuncConfigurations(string value) { Value = value; }

        public string Value { get; private set; }

        public static FuncConfigurations WeatherDataURL 
        { 
            get 
            {
                var weatherAPIProvider = Environment.GetEnvironmentVariable("WeatherAPIProvider");
                return new FuncConfigurations(weatherAPIProvider); 
            }
        }
        public static FuncConfigurations DBConnectionString 
        {
            get {
                var DataBaseConnectionString = Environment.GetEnvironmentVariable("DataBaseConnectionString");
                return 
                    new FuncConfigurations(DataBaseConnectionString); 
            } 
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
