using ControleDeGastos.Application.DTOs;
using ControleDeGastos.Application.UseCases.Interfaces;
using ControleDeGastos.Domain.Entities;
using ControleDeGastos.Domain.Repositories.PessoaRepository;

namespace ControleDeGastos.Application.UseCases
{    
    public class PessoaUseCase : IPessoaUseCase
    {
        // De modo geral, mantive os retornos dos métodos de casos de uso como string, para facilitar a comunicação (e o debug) com a camada de apresentação,
        // onde eu posso retornar mensagens mais amigáveis. 
        private readonly IPessoaRepository _pessoaRepository;
        public PessoaUseCase(IPessoaRepository pessoaRepository) => _pessoaRepository = pessoaRepository;

        public async Task<List<ResponsePessoaJson>> ListarPessoas()
        {
            var pessoas = await _pessoaRepository.ObterTodosAsync();
            return pessoas.Select(p => new ResponsePessoaJson(p.Id, p.Nome, p.Idade)).ToList();
        }

        public async Task<string> CriarPessoa(RequestCriaPessoaJson requestCriaPessoaJson)
        {
            await Validate(requestCriaPessoaJson);
            Pessoa pessoa = new Pessoa(requestCriaPessoaJson.Nome, requestCriaPessoaJson.Idade);

            await _pessoaRepository.AdicionarAsync(pessoa);

            return $"Pessoa '{pessoa.Nome}' criada com sucesso.";
        }

        public async Task<string> EditarPessoa(RequestEditarPessoa requestEditarPessoa)
        { 
            var pessoa = await _pessoaRepository.ObterPorIdAsync(requestEditarPessoa.Id);
            if (pessoa == null)
                throw new ArgumentException($"Pessoa não encontrada.");

            if (!string.IsNullOrWhiteSpace(requestEditarPessoa.Nome))
                pessoa.EditarNome(requestEditarPessoa.Nome);

            if (requestEditarPessoa.Idade.HasValue && requestEditarPessoa.Idade != 0)
                pessoa.EditarIdade(requestEditarPessoa.Idade.Value);

            await _pessoaRepository.AtualizarAsync(pessoa);

            return $"Pessoa '{pessoa.Nome}' editada com sucesso.";
        }

        public async Task<string> ExcluirPessoa(int id)
        {
            var pessoa = await _pessoaRepository.ObterPorIdAsync(id);
            if (pessoa == null)
                throw new ArgumentException($"Pessoa não encontrada.");

            await _pessoaRepository.ExcluirAsync(pessoa);
            return $"Pessoa '{pessoa.Nome}' excluída com sucesso.";
        }

        private async Task Validate(RequestCriaPessoaJson request)
        {
            // Essas validações especificamente aqui são um pouco de overengineering, pois eu ja valido 'Idade' no Dominio e 'Nome' é NotNull no BD.
            // Mas por pratica pessoal gosto de validar antes também.
            ArgumentNullException.ThrowIfNull(request);
                if (string.IsNullOrWhiteSpace(request.Nome))
                    throw new ArgumentException("O nome da pessoa é obrigatório.");
    
                if (request.Idade <= 0)
                    throw new ArgumentException("A idade da pessoa deve ser maior que zero.");
        }
    }
}
