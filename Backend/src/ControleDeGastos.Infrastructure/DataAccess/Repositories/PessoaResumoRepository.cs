using ControleDeGastos.Domain.Entities.Enums;
using ControleDeGastos.Domain.Entities.ReadModels;
using ControleDeGastos.Domain.Repositories.TransacaoRepository;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastos.Infrastructure.DataAccess.Repositories
{
    public class PessoaResumoRepository : IPessoaResumoRepository
    {
        private readonly ControleDeGastosDbContext _context;
        public PessoaResumoRepository(ControleDeGastosDbContext context) => _context = context;

        // Como as camadas de Infra e aplicação não se comunicam diretamente, eu preciso de um modelo de leitura específico para essa consulta, que é o PessoaResumoReadModel.
        // A DTO que vai para as camadas externas será mapeada a partir desse modelo de leitura, no useCase.
        public async Task<List<PessoaResumoReadModel>> ObterResumoAsync()
        { 
            return await _context.Pessoas
                .Select(p => new PessoaResumoReadModel
                { 
                    PessoaId = p.Id,
                    Nome = p.Nome,
                    TotalReceitas = p.Transacoes
                        .Where(t => t.Tipo == TipoTransacao.Receita)
                        .Sum(t => t.Valor.Valor),
                    TotalDespesas = p.Transacoes
                        .Where(t => t.Tipo == TipoTransacao.Despesa)
                        .Sum(t => t.Valor.Valor)
                })
                .ToListAsync();
        }
    }
}
