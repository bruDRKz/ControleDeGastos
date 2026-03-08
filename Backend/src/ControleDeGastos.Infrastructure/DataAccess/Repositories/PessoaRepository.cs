using ControleDeGastos.Domain.Entities;
using ControleDeGastos.Domain.Repositories.PessoaRepository;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastos.Infrastructure.DataAccess.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ControleDeGastosDbContext _context;

        public PessoaRepository(ControleDeGastosDbContext context) => _context = context;
        public async Task AdicionarAsync(Pessoa pessoa)
        {
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();

        }

        public async Task AtualizarAsync(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Pessoa pessoa)
        {             
           _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<Pessoa?> ObterPorIdAsync(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task<List<Pessoa>> ObterTodosAsync()
        {
            return await _context.Pessoas.AsNoTracking().ToListAsync();
        }
    }
}
