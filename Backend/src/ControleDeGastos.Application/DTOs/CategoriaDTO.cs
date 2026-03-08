using ControleDeGastos.Domain.Entities.Enums;

namespace ControleDeGastos.Application.DTOs
{
    public class CategoriaDTO
    {
        public int? Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public FinalidadeCategoria Finalidade { get; set; }
    }
}
