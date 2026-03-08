using ControleDeGastos.Application.DTOs;

namespace ControleDeGastos.Application.UseCases.Interfaces
{
    public interface IPessoaUseCase
    {
        Task<string> CriarPessoa(RequestCriaPessoaJson requestCriaPessoaJson);
        Task<string> EditarPessoa(RequestEditarPessoa requestEditarPessoa);
        Task<string> ExcluirPessoa(int id);
    }
}
