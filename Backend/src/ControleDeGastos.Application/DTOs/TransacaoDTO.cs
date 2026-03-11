using ControleDeGastos.Domain.Entities.Enums;

namespace ControleDeGastos.Application.DTOs
{
    public class TransacaoDTO
    {
        public int? Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public int CategoriaId { get; set; }
        public int PessoaId { get; set; }
    }
}
