using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SweetLife.Logic.Repositories.Mssql
{
    internal static class ServicesConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            File.ServicesConfigurator.Configure(services, configuration);
            Employee.ServicesConfigurator.Configure(services, configuration);
            TaxReceipt.ServicesConfigurator.Configure(services, configuration);
        }
    }
}
