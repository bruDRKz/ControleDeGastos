using ControleDeGastos.Application.UseCases;
using ControleDeGastos.Application.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace ControleDeGastos.Application
{
    public static class DependencyInjectionExtension
    {
        // Injeção de dependências da camada de aplicação, para adicionar os casos de uso.
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
        }
    
        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IPessoaUseCase, PessoaUseCase>();
            services.AddScoped<ICategoriaUseCase, CategoriaUseCase>();

        }
    }
}
