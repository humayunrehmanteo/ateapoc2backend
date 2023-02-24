using MediatR;
using Microsoft.Extensions.DependencyInjection;
using POC2.Application.Interfaces;
using POC2.Application.Service;
using System.Reflection;

namespace POC2.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IWeatherService, WeatherService>();

        }
    }
}
