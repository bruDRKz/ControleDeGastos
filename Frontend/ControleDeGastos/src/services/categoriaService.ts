import { API_URL } from "../api/config";
import type { Categoria } from "../types/Categoria";
import { erro } from "../utils/Alerts"



export async function getCategorias(): Promise<Categoria[]> {

    const response = await fetch(`${API_URL}/Categoria`);

    if (!response.ok) {
        throw new Error("Erro ao buscar categorias");
    }

    return response.json();
}

export async function createCategoria(descricao: string, finalidade: string): Promise<void>{
    const response = await fetch(`${API_URL}/Categoria`,{
        method: "POST",
        headers: {
             "Content-Type": "application/json"
        },
        body: JSON.stringify({
            descricao,
            finalidade           
        })
    });

    if(!response.ok){
        throw erro("Erro ao criar categoria");
    }
}