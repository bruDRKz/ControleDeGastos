namespace ControleDeGastos.Domain.Entities.ReadModels
{
    public class PessoaResumoReadModel
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }
    }
}
