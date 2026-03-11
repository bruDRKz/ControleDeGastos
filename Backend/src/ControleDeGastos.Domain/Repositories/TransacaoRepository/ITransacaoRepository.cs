using ControleDeGastos.Domain.Entities;

namespace ControleDeGastos.Domain.Repositories.TransacaoRepository
{
    public interface ITransacaoRepository
    {
        Task AdicionarAsync(Transacao transacao);
        Task<List<Transacao>> GetTransacoesAsync();

    }
}
