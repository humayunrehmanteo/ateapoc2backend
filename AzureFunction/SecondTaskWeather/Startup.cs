using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecondTaskWeather.Infrastructure;
using SecondTaskWeather.Services;
using System.IO;

[assembly: FunctionsStartup(typeof(SecondTaskWeather.Startup))]

namespace SecondTaskWeather
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();

            builder.Services.AddScoped<IExtractInfoService, ExtractInfoService>();
            builder.Services.AddScoped<IDataService, DataService>();


            builder.Services.AddDbContext<WeatherDBContext>(
                options => options.UseSqlServer(FuncConfigurations.DBConnectionString.Value));
        }
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            FunctionsHostBuilderContext context = builder.GetContext();

            builder.ConfigurationBuilder
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, "appsettings.json"), optional: true, reloadOnChange: false)
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, $"appsettings.{context.EnvironmentName}.json"), optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();
        }
    }
}
