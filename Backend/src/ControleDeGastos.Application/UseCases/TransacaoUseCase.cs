using ControleDeGastos.Application.DTOs;
using ControleDeGastos.Application.UseCases.Interfaces;
using ControleDeGastos.Domain.Entities;
using ControleDeGastos.Domain.Entities.Enums;
using ControleDeGastos.Domain.Entities.ValueObjects;
using ControleDeGastos.Domain.Repositories.PessoaRepository;
using ControleDeGastos.Domain.Repositories.TransacaoRepository;

namespace ControleDeGastos.Application.UseCases
{
    public class TransacaoUseCase : ITransacaoUseCase
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaResumoRepository _pessoaResumoRepository;
        public TransacaoUseCase(ITransacaoRepository transacaoRepository, IPessoaRepository pessoaRepository, IPessoaResumoRepository pessoaResumoRepository) 
        {
            _transacaoRepository = transacaoRepository;
            _pessoaRepository = pessoaRepository;
            _pessoaResumoRepository = pessoaResumoRepository;

        } 

        public async Task AdicionarTransacaoAsync(TransacaoDTO transacaoDTO)
        { 
            if(string.IsNullOrEmpty(transacaoDTO.Descricao))
                throw new ArgumentException("A descrição da transação é obrigatória.");
            if (transacaoDTO.Valor <= 0)
                throw new ArgumentException("O valor da transação deve ser maior que zero");

            if (await _pessoaRepository.PessoaMenorDeIdade(transacaoDTO.PessoaId) && transacaoDTO.TipoTransacao == TipoTransacao.Receita)
                throw new InvalidOperationException("Pessoas menores de idade não podem registrar receitas.");

            var valor = new Moeda(transacaoDTO.Valor);
            Transacao transacao = new Transacao(
                transacaoDTO.Descricao,
                valor,
                transacaoDTO.TipoTransacao,
                transacaoDTO.CategoriaId,
                transacaoDTO.PessoaId
                );

            await _transacaoRepository.AdicionarAsync(transacao);
        }

        public async Task<List<TransacaoDTO>> GetTransacoesDTOAsync()
        { 
            List<Transacao> transacoes = await _transacaoRepository.GetTransacoesAsync(); 
            return transacoes.Select(t => new TransacaoDTO
            {
                Id = t.Id,
                Descricao = t.Descricao,
                Valor = t.Valor.Valor,
                TipoTransacao = t.Tipo,
                CategoriaId = t.CategoriaId,
                PessoaId = t.PessoaId
            }).ToList();
        }
    }
}
