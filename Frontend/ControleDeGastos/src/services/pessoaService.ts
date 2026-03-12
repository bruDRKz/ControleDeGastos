import { API_URL } from "../api/config";
import type { Pessoa } from "../types/Pessoa";
import { erro } from "../utils/Alerts"

export async function getPessoas(): Promise<Pessoa[]> {

    const response = await fetch(`${API_URL}/Pessoas`);

    if (!response.ok) {
        throw erro("Erro ao buscar pessoas");
    }

    const data: Pessoa[] = await response.json();

    return data;
}


export async function createPessoa(nome: string, idade: number): Promise<void> {

    const response = await fetch(`${API_URL}/Pessoas`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            nome,
            idade
        })
    });

    if (!response.ok) {
        throw erro("Erro ao criar pessoa");
    }
}

export async function deletePessoa(id: number) : Promise<void>{
    const response = await fetch(`${API_URL}/Pessoas?id=${id}`, {
        method: "DELETE"        
    })

    if(!response.ok)
        throw erro("Erro ao deletar pessoa.")
}

export async function updatePessoa(id: number, nome: string, idade: number): Promise<void>{

    const response = await fetch(`${API_URL}/Pessoas`, {
        method: "PATCH",
        headers: {
           "Content-Type": "application/json" 
        },        
        body: JSON.stringify({
            id,
            nome,
            idade
        })
    });

    if(!response.ok){
        throw erro("Erro ao atualizar pessoa.")
    }

}