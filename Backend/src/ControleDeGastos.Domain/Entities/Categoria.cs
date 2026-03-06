using ControleDeGastos.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeGastos.Domain.Entities
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(400)]
        public string Descricao { get; private set; } = string.Empty;

        [Required]
        public FinalidadeCategoria Finalidade { get; private set; }
        public List<Transacao>? Transacoes { get; private set; } // Propriedade de navegação, apenas para facilitar consultas e garantir integridade referencial. 
        private Categoria() { } // ctor do EF Core
        public Categoria(string descricao, FinalidadeCategoria finalidade)
        {
            Descricao = descricao;
            Finalidade = finalidade;
        }
    }
}
