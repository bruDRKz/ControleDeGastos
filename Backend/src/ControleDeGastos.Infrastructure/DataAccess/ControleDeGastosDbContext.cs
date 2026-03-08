using ControleDeGastos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastos.Infrastructure.DataAccess
{
    public class ControleDeGastosDbContext : DbContext
    {
        public ControleDeGastosDbContext(DbContextOptions<ControleDeGastosDbContext> options) : base(options) { }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Preciso avisar o EF que Valor é um ValueObject e não uma tabela, para que ele possa tipar corretamente a coluna.
            modelBuilder.Entity<Transacao>()
                .OwnsOne(t => t.Valor, moeda =>
                {
                    moeda.Property(m => m.Valor)
                         .HasColumnName("Valor")
                         .IsRequired();
                });

            // COnfig de Cascade Delete para (1 Pessoa <-> N Transações).
            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Transacoes)
                .WithOne()
                .HasForeignKey(t => t.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
