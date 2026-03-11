using ControleDeGastos.Domain.Repositories.CategoriaRepository;
using ControleDeGastos.Domain.Repositories.PessoaRepository;
using ControleDeGastos.Domain.Repositories.TransacaoRepository;
using ControleDeGastos.Infrastructure.DataAccess;
using ControleDeGastos.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleDeGastos.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        // Injeção de dependências da camada de infraestrutura, para adicionar os repositórios e o contexto do banco de dados.
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ControleDeGastosDbContext>(options =>
            options.UseSqlite(connectionString));            
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<IPessoaResumoRepository, PessoaResumoRepository>();

        }
    }
}
