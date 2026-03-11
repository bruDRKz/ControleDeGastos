using ControleDeGastos.Application.DTOs;
using ControleDeGastos.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AdicionarTransacao(
            [FromServices] ITransacaoUseCase transacaoUseCase,
            [FromBody] TransacaoDTO requestTransacaoDTO)
        {
            try
            {
                await transacaoUseCase.AdicionarTransacaoAsync(requestTransacaoDTO);
                return Created(string.Empty, "Transação criada com sucesso.");
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTransacoes(
            [FromServices] ITransacaoUseCase transacaoUseCase)
        {
            try
            {
                List<TransacaoDTO> transacoes = await transacaoUseCase.GetTransacoesDTOAsync();
                return Ok(transacoes);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        [HttpGet("resumo")]
        public async Task<IActionResult> GetResumoPessoas(
            [FromServices] IResumoPessoaUseCase resumoPessoaUseCase)
        {
            try
            {
                ResumoPessoasResponseDTO resumoPessoas = await resumoPessoaUseCase.GetResumo();                
                return Ok(resumoPessoas);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}
