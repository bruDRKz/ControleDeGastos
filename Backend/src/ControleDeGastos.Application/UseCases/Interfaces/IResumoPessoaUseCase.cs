using ControleDeGastos.Application.DTOs;

namespace ControleDeGastos.Application.UseCases.Interfaces
{
    public interface IResumoPessoaUseCase
    {
        Task<ResumoPessoasResponseDTO> GetResumo();
    }
}
