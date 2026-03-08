namespace ControleDeGastos.Application.DTOs
{
    public class RequestEditarPessoa
    {
        public int Id { get; set; }
        public string? Nome { get; set; } = string.Empty;
        public int? Idade { get; set; }
    }
}
