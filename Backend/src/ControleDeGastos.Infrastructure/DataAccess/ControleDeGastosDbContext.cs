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
            modelBuilder.Entity<Transacao>()
                .OwnsOne(t => t.Valor, moeda =>
                {
                    moeda.Property(m => m.Valor)
                         .HasColumnName("Valor")
                         .IsRequired();
                });
        }
    }
}
