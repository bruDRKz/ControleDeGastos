using ControleDeGastos.Domain.Entities;
using ControleDeGastos.Domain.Repositories.TransacaoRepository;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastos.Infrastructure.DataAccess.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly ControleDeGastosDbContext _context;
        public TransacaoRepository(ControleDeGastosDbContext context) => _context = context;

        public async Task AdicionarAsync(Transacao transacao)
        {

            _context.Transacoes.Add(transacao);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Transacao>> GetTransacoesAsync()
        { 
            return await _context.Transacoes.ToListAsync();
        }
    }
}
