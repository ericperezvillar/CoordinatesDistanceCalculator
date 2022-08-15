using CoreLog.Interfaces;
using CoreLog.Logger;
using CoreLog.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

namespace CoreLog
{
    public static class LogConfiguration
    {
        public static void ConfigureSerilog(this IServiceCollection services, IConfiguration configuration)
        {
            var coreLogConfiguration = configuration.GetSection("CoreLogConfiguration");
            services.Configure<SettingConfiguration>(coreLogConfiguration);
            services.AddScoped<ICoreLogger, CoreLogger>();

            var settingsConfiguration = coreLogConfiguration.Get<SettingConfiguration>();
            var logFile = GetLogFilePath(settingsConfiguration);

            /*
             Serilog implemented with Txt file only in order to avoid Database configuration
             */

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                .WriteTo.File(logFile, rollingInterval: RollingInterval.Day, shared: true)
                .CreateLogger();

            services.AddLogging((builder) =>
            {
                builder.AddSerilog(dispose: true);
            });
        }

        private static string GetLogFilePath(SettingConfiguration settingsConfiguration)
        {
            if (string.IsNullOrWhiteSpace(settingsConfiguration.LogPath))
                return $"{Environment.CurrentDirectory}/{settingsConfiguration.LogNamePrefix}.txt";
            return $"{settingsConfiguration.LogPath}/{settingsConfiguration.LogNamePrefix}.txt";
        }


    }
}
