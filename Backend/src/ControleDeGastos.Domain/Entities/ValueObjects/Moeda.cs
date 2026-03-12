namespace ControleDeGastos.Domain.Entities.ValueObjects
{
    public class Moeda
    {
        // Objeto de valor, ao invés de usar um tipo primitivo decimal para representar o valor da transação,
        // crio um objeto de valor para garantir que o valor seja sempre positivo e para encapsular qualquer nova lógica relacionada a valores monetários.
        public decimal Valor { get; private set; }
        public Moeda() { }
        public Moeda(decimal valor)
        {
            if (valor <= 0)
                throw new InvalidOperationException("Valor deve ser positivo.");
            Valor = valor;
        }
    }
}
