import { type Transacao } from "../types/Transacao"

type Pessoa = {
    id: number
    nome: string
}

type Categoria = {
    id: number
    descricao: string
}

type Props = {
    transacoes: Transacao[]
    pessoas: Pessoa[]
    categorias: Categoria[]
}

function TransactionTable({ transacoes, pessoas, categorias }: Props) {

    function getPessoaNome(pessoaId: number) {
        return pessoas.find(p => p.id === pessoaId)?.nome ?? "Desconhecido"
    }

    function getCategoriaDescricao(categoriaId: number) {
        return categorias.find(c => c.id === categoriaId)?.descricao ?? "Desconhecida"
    }

function isReceita(tipo: "Receita" | "Despesa") {
    return tipo === "Receita"
}

function formatTipo(tipo: "Receita" | "Despesa") {
    return tipo
}

function formatValor(valor: number, tipo: "Receita" | "Despesa") {
    const receita = isReceita(tipo)

    const valorFormatado = new Intl.NumberFormat("pt-BR", {
        style: "currency",
        currency: "BRL"
    }).format(valor)

    return {
        texto: `${receita ? "+" : "-"} ${valorFormatado}`,
        cor: receita ? "text-green-600" : "text-red-600"
    }
}

    return (
        <div className="bg-white shadow rounded-lg overflow-hidden">

            <table className="w-full">

                <thead className="bg-gray-100">
                    <tr className="text-center">
                        <th className="p-3">Descrição</th>
                        <th className="p-3">Pessoa</th>
                        <th className="p-3">Categoria</th>
                        <th className="p-3">Tipo</th>
                        <th className="p-3">Valor</th>
                    </tr>
                </thead>

                <tbody className="text-center">

                    {transacoes.map(t => {

                        const valorFormatado = formatValor(t.valor, t.tipoTransacao)

                        return (
                            <tr key={t.id} className="border-t">

                                <td className="p-3">
                                    {t.descricao}
                                </td>

                                <td className="p-3">
                                    {getPessoaNome(t.pessoaId)}
                                </td>

                                <td className="p-3">
                                    {getCategoriaDescricao(t.categoriaId)}
                                </td>

                                <td className="p-3">
                                    {formatTipo(t.tipoTransacao)}
                                </td>

                                <td className={`p-3 font-semibold ${valorFormatado.cor}`}>
                                    {valorFormatado.texto}
                                </td>

                            </tr>
                        )
                    })}

                </tbody>

            </table>

        </div>
    )
}

export default TransactionTable