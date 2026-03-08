using ControleDeGastos.Domain.Entities;
using ControleDeGastos.Domain.Repositories.CategoriaRepository;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastos.Infrastructure.DataAccess.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ControleDeGastosDbContext _context;      
        public CategoriaRepository(ControleDeGastosDbContext context) =>_context = context;

        public async Task AdicionarAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
