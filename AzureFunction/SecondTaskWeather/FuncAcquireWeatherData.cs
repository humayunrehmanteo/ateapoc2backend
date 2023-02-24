using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SecondTaskWeather.Services;

namespace SecondTaskWeather
{
    public class FuncAcquireWeatherData
    {
        private readonly IExtractInfoService _extractInfoService;
        public FuncAcquireWeatherData(IExtractInfoService extractInfoService)
        {
            _extractInfoService = extractInfoService;
        }

        [FunctionName("FuncAcquireWeatherData")]
        public async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            try
            {
                await _extractInfoService.GetStoreWeatherDataAsync();
            }
            catch (Exception ex)
            {
                log.LogInformation($"Exception: {ex.Message} on {DateTime.Now}");
            }
        }
    }
}
