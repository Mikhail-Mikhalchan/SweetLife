using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SweetLife.Logic.Settings
{
    internal static class ServicesConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            DataProviders.ServicesConfigurator.Configure(services, configuration);            
        }
    }
}