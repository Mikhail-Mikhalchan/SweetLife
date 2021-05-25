using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SweetLife.Logic
{
    public static class ServicesConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            DataProvider.ServicesConfigurator.Configure(services, configuration);
            Repositories.ServicesConfigurator.Configure(services, configuration);
            Services.ServicesConfigurator.Configure(services, configuration);
        }
    }
}
