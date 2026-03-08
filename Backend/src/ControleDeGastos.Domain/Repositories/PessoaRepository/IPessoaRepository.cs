using ControleDeGastos.Domain.Entities;

namespace ControleDeGastos.Domain.Repositories.PessoaRepository
{
    public interface IPessoaRepository
    {
            Task<Pessoa?> ObterPorIdAsync(int id);
            Task<List<Pessoa>> ObterTodosAsync();
            Task AdicionarAsync(Pessoa pessoa);
            Task AtualizarAsync(Pessoa pessoa);
            Task ExcluirAsync(Pessoa pessoa);
    }
}
