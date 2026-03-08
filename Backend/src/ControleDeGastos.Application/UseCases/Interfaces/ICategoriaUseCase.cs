using ControleDeGastos.Application.DTOs;
using ControleDeGastos.Domain.Entities;

namespace ControleDeGastos.Application.UseCases.Interfaces
{
    public interface ICategoriaUseCase
    {
        Task<string> CriarCategoria(CategoriaDTO requestCriarCategoria);
        Task<List<CategoriaDTO>> GetCategoriasAsync();
    }
}
