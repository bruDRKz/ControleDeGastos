using ControleDeGastos.Application.DTOs;
using ControleDeGastos.Application.UseCases.Interfaces;
using ControleDeGastos.Domain.Entities;
using ControleDeGastos.Domain.Repositories.CategoriaRepository;

namespace ControleDeGastos.Application.UseCases
{
    public class CategoriaUseCase : ICategoriaUseCase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaUseCase(ICategoriaRepository categoriaRepository) => _categoriaRepository = categoriaRepository;
        public async Task<string> CriarCategoria(CategoriaDTO requestCriarCategoria)
        {
            if (string.IsNullOrEmpty(requestCriarCategoria.Descricao))
                throw new ArgumentException("A descrição da categoria é obrigatória.");

            Categoria categoria = new Categoria(requestCriarCategoria.Descricao, requestCriarCategoria.Finalidade);
            await _categoriaRepository.AdicionarAsync(categoria);

            return $"Categoria {categoria.Descricao} criada com sucesso.";
        }

        public async Task<List<CategoriaDTO>> GetCategoriasAsync()
        {
            var categorias = await _categoriaRepository.GetCategoriasAsync();

            // Como optei por uma arquitetura DDD, as entidades não devem ser expostas para a camada externa da aplicação.
            // Porém, por regra, as DTOs são armazenadas na camada de aplicação, mas Infraestrutura não conhece Aplicação, então, para evitar dependências incorretas,
            // eu faço um mapeamento manual da entidade para a minha DTO dentro do retorno. (Em tese, isso poderia ser evitado criando uma camada a mais, Comunication, porém seria overengineering)
            return categorias
                .Select(c => new CategoriaDTO
                {
                    Id = c.Id,
                    Descricao = c.Descricao,
                    Finalidade = c.Finalidade
                })
                .ToList();
        }
    }
}
