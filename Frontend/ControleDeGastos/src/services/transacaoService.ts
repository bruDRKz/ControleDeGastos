import { API_URL } from "../api/config";
import type { Transacao } from "../types/Transacao";


export async function getTransacoes(): Promise<Transacao[]> {
    
    const response = await fetch(`${API_URL}/Transacoes`);

    if(!response.ok){
        throw new Error("Erro ao buscar transações.");
    }
        
    return response.json();
}

export async function criarTransacao(transacao: Transacao): Promise<void> {

    const response = await fetch(`${API_URL}/Transacoes`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(transacao)
    });

    if (!response.ok) {
        throw new Error("Erro ao criar transação");
    }
}