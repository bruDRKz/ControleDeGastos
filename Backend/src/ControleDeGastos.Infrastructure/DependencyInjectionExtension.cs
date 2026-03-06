using ControleDeGastos.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleDeGastos.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        { 
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ControleDeGastosDbContext>(options =>
            options.UseSqlite(connectionString));            
        }
    }
}
