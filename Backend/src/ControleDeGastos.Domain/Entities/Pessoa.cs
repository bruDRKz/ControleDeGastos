using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ControleDeGastos.Domain.Entities
{    

    [Table("Pessoas")]
    public class Pessoa
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(400)]
        public string Nome { get; private set; }

        [Range(0, 100)] // Range só pra garantir, a validação principal é no construtor.
        public int Idade { get; private set; }
        public List<Transacao> Transacoes { get; private set; } = new();
        private Pessoa() { } // ctor do EF Core

        public Pessoa(string nome, int idade)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.");

            if (nome.Length > 200)
                throw new ArgumentException("Nome deve ter no máximo 200 caracteres.");

            if (idade < 0)
                throw new ArgumentException("Idade inválida.");

            Nome = nome;
            Idade = idade;
        }

        public bool MenorDeIdade()
        {
            return Idade < 18;
        }
    }
}
