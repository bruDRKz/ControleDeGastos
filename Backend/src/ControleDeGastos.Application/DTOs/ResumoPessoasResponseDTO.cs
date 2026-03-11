namespace ControleDeGastos.Application.DTOs
{
    public class ResumoPessoasResponseDTO
    {
        public List<PessoaResumoDTO> Pessoas { get; set; } = new();

        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }

        public decimal Saldo => TotalReceitas - TotalDespesas;
    }
}
