using ControleDeGastos.Domain.Entities.ReadModels;

namespace ControleDeGastos.Domain.Repositories.TransacaoRepository
{
    public interface IPessoaResumoRepository
    {
          Task<List<PessoaResumoReadModel>> ObterResumoAsync();
    }
}
