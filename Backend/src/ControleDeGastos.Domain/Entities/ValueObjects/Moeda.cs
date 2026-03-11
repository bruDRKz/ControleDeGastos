namespace ControleDeGastos.Domain.Entities.ValueObjects
{
    public class Moeda
    {
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
