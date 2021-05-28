using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SweetLife.Logic
{
    public static class ServicesConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            DataProviders.ServicesConfigurator.Configure(services, configuration);
            Repositories.ServicesConfigurator.Configure(services, configuration);
            Services.ServicesConfigurator.Configure(services, configuration);
            Settings.ServicesConfigurator.Configure(services, configuration);
        }
    }
}
