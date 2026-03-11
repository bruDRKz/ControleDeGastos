using ControleDeGastos.Application.DTOs;

namespace ControleDeGastos.Application.UseCases.Interfaces
{
    public interface ITransacaoUseCase
    {
        Task AdicionarTransacaoAsync(TransacaoDTO transacaoDTO);
        Task<List<TransacaoDTO>> GetTransacoesDTOAsync();
    }
}
