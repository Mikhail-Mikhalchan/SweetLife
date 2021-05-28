using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SweetLife.Logic.Repositories.Mssql.Employee.Fire
{
    internal static class ServicesConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository, Repository>();
        }
    }
}
