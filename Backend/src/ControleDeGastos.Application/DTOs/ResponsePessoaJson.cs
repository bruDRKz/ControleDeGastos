namespace ControleDeGastos.Application.DTOs
{
    public class ResponsePessoaJson
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public ResponsePessoaJson(int id, string nome, int idade)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
        }
    }
}
