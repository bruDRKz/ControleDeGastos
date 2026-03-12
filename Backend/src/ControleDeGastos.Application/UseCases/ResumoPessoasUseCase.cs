using ControleDeGastos.Application.DTOs;
using ControleDeGastos.Application.UseCases.Interfaces;
using ControleDeGastos.Domain.Entities.ReadModels;
using ControleDeGastos.Domain.Repositories.TransacaoRepository;

namespace ControleDeGastos.Application.UseCases
{
    public class ResumoPessoasUseCase : IResumoPessoaUseCase
    {
        private readonly IPessoaResumoRepository _pessoaResumoRepository;
        public ResumoPessoasUseCase(IPessoaResumoRepository pessoaResumoRepository) => _pessoaResumoRepository = pessoaResumoRepository;

        public async Task<ResumoPessoasResponseDTO> GetResumo()
        {
            List<PessoaResumoReadModel> pessoas = await _pessoaResumoRepository.ObterResumoAsync();

            // Aqui eu monto o conjunto de dados que é exposto no dashboard, onde cada pessoa tem seu resumo individual e também o total geral de receitas e despesas.
            ResumoPessoasResponseDTO resumoPessoasDTO = new ResumoPessoasResponseDTO
            {
                Pessoas = pessoas.Select(p => new PessoaResumoDTO
                {
                    PessoaId = p.PessoaId,
                    Nome = p.Nome,
                    TotalReceitas = p.TotalReceitas,
                    TotalDespesas = p.TotalDespesas
                }).ToList(),
                TotalReceitas = pessoas.Sum(p => p.TotalReceitas),
                TotalDespesas = pessoas.Sum(p => p.TotalDespesas)
            };

            return resumoPessoasDTO;
        }
    }
}
