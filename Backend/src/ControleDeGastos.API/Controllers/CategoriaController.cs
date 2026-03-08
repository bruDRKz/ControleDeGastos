using ControleDeGastos.Application.DTOs;
using ControleDeGastos.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCategorias(
            [FromServices] ICategoriaUseCase categoriaUseCase)
        {
            try
            {
                var result = await categoriaUseCase.GetCategoriasAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarCategoria(
            [FromServices] ICategoriaUseCase categoriaUseCase,
            [FromBody] CategoriaDTO request)
        {
            try
            {
                var result = await categoriaUseCase.CriarCategoria(request);
                return Created(string.Empty, result);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }

        }
    }
}
