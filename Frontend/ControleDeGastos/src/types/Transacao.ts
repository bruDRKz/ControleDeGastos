export type Transacao = {
    id?: number
    descricao: string
    valor: number
    tipoTransacao: "Receita" | "Despesa"
    categoriaId: number
    pessoaId: number
}