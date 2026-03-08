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

            if (nome.Length > 400)
                throw new ArgumentException("Nome deve ter no máximo 400 caracteres.");

            if (idade < 0)
                throw new ArgumentException("Idade inválida.");

            Nome = nome;
            Idade = idade;
        }

        // Método para verificar se a pessoa é menor de idade, apenas para aplicar a regra de transções.
        public bool MenorDeIdade()
        {
            return Idade < 18;
        }

        // Como meus atributos so privados preciso criar metodos de dominio para editar cada um.
        // Método para editar o nome da pessoa, com as mesmas validações do construtor.
        public void EditarNome(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome))
                throw new ArgumentException("O nome da pessoa é obrigatório.");
            if (novoNome.Length > 400)
                throw new ArgumentException("O nome da pessoa deve ter no máximo 200 caracteres.");
            Nome = novoNome;
        }
        // Método para editar a idade da pessoa, com as mesmas validações do construtor.
        public void EditarIdade(int novaIdade)
        {
            if (novaIdade < 0)
                throw new ArgumentException("A idade da pessoa deve ser maior ou igual a zero.");
            Idade = novaIdade;
        }
    }
}
