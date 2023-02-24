
namespace SecondTaskWeather.Services
{
    internal class ServiceMessages
    {
        private ServiceMessages(string value) { Value = value; }

        public string Value { get; private set; }

        public static ServiceMessages HttpClientNullObject { get { return new ServiceMessages("Http client object is null"); } }
        public static ServiceMessages AzureStorageNullObject { get { return new ServiceMessages("Azure storage connectivity object is null"); } }

        public override string ToString()
        {
            return Value;
        }
    }
}
