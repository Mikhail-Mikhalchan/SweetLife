using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SweetLife.Logic.Repositories.Mssql.Employee
{
    internal static class ServicesConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            Fire.ServicesConfigurator.Configure(services, configuration);
            GetById.ServicesConfigurator.Configure(services, configuration);
            Insert.ServicesConfigurator.Configure(services, configuration);
            List.ServicesConfigurator.Configure(services, configuration);
            SaveNotification.ServicesConfigurator.Configure(services, configuration);
            SaveTaxReceipt.ServicesConfigurator.Configure(services, configuration);
            Update.ServicesConfigurator.Configure(services, configuration);
        }
    }
}
