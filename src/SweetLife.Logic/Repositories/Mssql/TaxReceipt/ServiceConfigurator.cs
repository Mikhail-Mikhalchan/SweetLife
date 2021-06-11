using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SweetLife.Logic.Repositories.Mssql.TaxReceipt
{
    internal static class ServicesConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            List.ServicesConfigurator.Configure(services, configuration);
        }
    }
}
