using ControleDeGastos.Domain.Entities.Enums;
using ControleDeGastos.Domain.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace ControleDeGastos.Domain.Entities
{
    [Table("Transacoes")]
    public class Transacao
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(400)]
        public string Descricao { get; private set; } = string.Empty;

        [Required]
        public Moeda Valor { get; private set; }
        public TipoTransacao Tipo { get; private set; }
        public int CategoriaId { get; private set; }
        public int PessoaId { get; private set; }

        // Ctor privado do EF Core
        private Transacao() { }

        public Transacao(
            string descricao,
            Moeda valor,
            TipoTransacao tipoTransacao,
            int categoriaId,
            int pessoaId)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("Descrição é obrigatória.");

            if (descricao.Length > 400)
                throw new ArgumentException("Descrição deve ter no máximo 400 caracteres.");

            Descricao = descricao;
            Valor = valor; // Valido no valueObject, posso atribuir despreocupado aqui.
            Tipo = tipoTransacao;
            CategoriaId = categoriaId;
            PessoaId = pessoaId;
        }
    }
}
