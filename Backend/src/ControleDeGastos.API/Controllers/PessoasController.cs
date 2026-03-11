using ControleDeGastos.Application.DTOs;
using ControleDeGastos.Application.UseCases.Interfaces;
using ControleDeGastos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ControleDeGastos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ListarPessoas(
            [FromServices] IPessoaUseCase pessoaUseCase)
        {
            try
            {
                var result = await pessoaUseCase.ListarPessoas();
                return Ok(result);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CriarPessoa(
            [FromServices] IPessoaUseCase pessoaUseCase,
            [FromBody] RequestCriaPessoaJson request)
        {
            // Pratica que particularmente gosto de usar: 
            // Colocar o Try/Catch na camada mais externa possivel da API, para que eu não precise tratar erros nas camadas internas,
            // ja que a responsabilidade desse tratamento deve sempre ser do chamador.
            try
            {
                var result = await pessoaUseCase.CriarPessoa(request);

                // Retorna o status code 201, indicando que a pessoa foi criada com sucesso.
                return Created(string.Empty, result);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> EditarPessoa(
            [FromServices] IPessoaUseCase pessoaUseCase,
            [FromBody] RequestEditarPessoa request)
        {
            try
            {
                var result = await pessoaUseCase.EditarPessoa(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirPessoa(
            [FromServices] IPessoaUseCase pessoaUseCase,
            [FromQuery] int id)
        {
            try
            {
                var result = await pessoaUseCase.ExcluirPessoa(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}

