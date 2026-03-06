using ControleDeGastos.Domain.Entities;
using ControleDeGastos.Domain.Repositories.PessoaRepository;

namespace ControleDeGastos.Infrastructure.DataAccess.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        public Task AdicionarAsync(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarAsync(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Pessoa?> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Pessoa>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
