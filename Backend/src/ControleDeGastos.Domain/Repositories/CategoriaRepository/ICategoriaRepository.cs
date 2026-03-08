using ControleDeGastos.Domain.Entities;

namespace ControleDeGastos.Domain.Repositories.CategoriaRepository
{
    public interface ICategoriaRepository
    {
        Task AdicionarAsync(Categoria categoria);
        Task<List<Categoria>> GetCategoriasAsync();
    }
}
