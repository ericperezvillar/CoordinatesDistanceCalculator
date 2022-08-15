using Application.Cache;
using Application.Helpers;
using Application.Interfaces;
using Application.Services;
using Application.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SettingsEnvironment>(configuration.GetSection("Environment"));
            services.AddScoped<IDistanceService, DistanceService>();
            services.AddScoped<IHaversineCalculator, HaversineCalculator>();
            services.AddScoped<ICacheHelper, CacheHelper>();
            services.AddScoped<IMeasureCache, MeasureCache>();
            services.AddScoped<ICoordinatesValidator, CoordinatesValidator>();
        }
    }
}
