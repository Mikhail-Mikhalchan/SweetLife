using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using O = SweetLife.Logic.Settings.DataProviders.Mssql;

namespace SweetLife.Logic.DataProviders.Mssql
{
    internal static class ServicesConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDataProvider, DataProvider>();

            services.AddScoped<ISettings>(serviceProvider =>
            {
                var settings = serviceProvider.GetService<IOptions<O.Settings>>().Value;
                settings.Validate();
                return settings;
            });
        }
    }
}