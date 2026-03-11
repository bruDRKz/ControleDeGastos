using ControleDeGastos.Application.DTOs;

namespace ControleDeGastos.Application.UseCases.Interfaces
{
    public interface IPessoaUseCase
    {
        Task<List<ResponsePessoaJson>> ListarPessoas();
        Task<string> CriarPessoa(RequestCriaPessoaJson requestCriaPessoaJson);
        Task<string> EditarPessoa(RequestEditarPessoa requestEditarPessoa);
        Task<string> ExcluirPessoa(int id);
    }
}
