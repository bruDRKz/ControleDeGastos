import { API_URL } from "../api/config";
export type PessoaResumo = {
    pessoaId: number
    nome: string
    totalReceitas: number
    totalDespesas: number
    saldo: number
}

export type ResumoResponse = {
    pessoas: PessoaResumo[]
    totalReceitas: number
    totalDespesas: number
    saldo: number
}

export async function getResumo(): Promise<ResumoResponse> {

    const response = await fetch(`${API_URL}/Transacoes/resumo`);

    if (!response.ok) {
        throw new Error("Erro ao buscar resumo");
    }

    return response.json();
}