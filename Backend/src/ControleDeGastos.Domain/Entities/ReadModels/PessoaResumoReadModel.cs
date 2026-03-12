namespace ControleDeGastos.Domain.Entities.ReadModels
{
    public class PessoaResumoReadModel
    {
        // ReadModel para retornar um resumo das transações de uma pessoa,
        // de modo que meu repository consiga acessar, ja que as DTOs estão em outra camada.
        public int PessoaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }
    }
}
