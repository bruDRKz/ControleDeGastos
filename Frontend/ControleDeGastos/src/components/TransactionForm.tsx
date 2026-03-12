import { useState } from "react"
import { criarTransacao } from "../services/transacaoService"
import type { Pessoa } from "../types/Pessoa"
import type { Categoria } from "../types/Categoria"

type Props = {
    pessoas: Pessoa[]
    categorias: Categoria[]
    onSucesso: () => void
}

type TipoTransacao = "Receita" | "Despesa"

function TransactionForm({ pessoas, categorias, onSucesso }: Props) {

    const [descricao, setDescricao] = useState("")
    const [valor, setValor] = useState("")
    const [tipo, setTipo] = useState<TipoTransacao>("Receita")
    const [pessoaId, setPessoaId] = useState<number | undefined>()
    const [categoriaId, setCategoriaId] = useState<number | undefined>()

    function validarTransacao() {

        if (!descricao || !valor || !pessoaId || !categoriaId) {
            return "Preencha todos os campos."
        }

        const pessoa = pessoas.find(p => p.id === pessoaId)
        const categoria = categorias.find(c => c.id === categoriaId)

        if (pessoa && pessoa.idade < 18 && tipo === "Receita") {
            return "Menores de idade não podem possuir receitas."
        }

        if (categoria) {
            if (categoria.finalidade === "Despesa" && tipo === "Receita") {
                return "Essa categoria permite apenas despesas."
            }

            if (categoria.finalidade === "Receita" && tipo === "Despesa") {
                return "Essa categoria permite apenas receitas."
            }

        }

        return null
    }

    async function handleSubmit() {

        const erro = validarTransacao()

        if (erro) {
            return
            // Adicionar alert de erro aqui
        }

        await criarTransacao({
            descricao,
            valor: Number(valor),
            tipoTransacao: tipo,
            pessoaId: pessoaId!,
            categoriaId: categoriaId!
        })

        onSucesso()
    }

    return (

        <div className="space-y-4">

            <h2 className="text-xl font-semibold mb-4">
                    Nova Transação
            </h2>
            <input
                type="text"
                placeholder="Descrição"
                value={descricao}
                onChange={(e) => setDescricao(e.target.value)}
                className="border p-2 rounded w-full"
            />

            <input
                type="number"
                placeholder="Valor"
                value={valor}
                onChange={(e) => setValor(e.target.value)}
                className="border p-2 rounded w-full"
            />

            <select
                value={tipo}
                onChange={(e) => setTipo(e.target.value as TipoTransacao)}
                className="border p-2 rounded w-full"
            >
                <option value="Receita">Receita</option>
                <option value="Despesa">Despesa</option>
            </select>

            <select
                value={pessoaId ?? ""}
                onChange={(e) => setPessoaId(e.target.value ? Number(e.target.value) : undefined)}
                className="border p-2 rounded w-full"
            >
                <option value="">Selecione uma pessoa</option>

                {pessoas.map(p => (
                    <option key={p.id} value={p.id}>
                        {p.nome}
                    </option>
                ))}
            </select>

            <select
                value={categoriaId ?? ""}
                onChange={(e) => setCategoriaId(e.target.value ? Number(e.target.value) : undefined)}
                className="border p-2 rounded w-full"
            >
                <option value="">Selecione uma categoria</option>

                {categorias.map(c => (
                    <option key={c.id} value={c.id}>
                        {c.descricao}
                    </option>
                ))}
            </select>

            <button
                onClick={handleSubmit}
                className="bg-indigo-600 text-white px-4 py-2 rounded w-full"
            >
                Criar Transação
            </button>

        </div>

    )
}

export default TransactionForm