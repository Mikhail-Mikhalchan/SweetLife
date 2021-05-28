using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SweetLife.Logic.Settings.DataProviders.Mssql
{
    internal static class ServicesConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Settings>(options => configuration.Bind(Constants.SettingsKey, options));
        }
    }
}