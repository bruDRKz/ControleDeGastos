import { useEffect, useState } from "react";
import Layout from "../components/Layout";
import Modal from "../components/Modal";

import { getCategorias, createCategoria } from "../services/categoriaService";
import type { Categoria } from "../types/Categoria";

import CategoriaList from "../components/CategoriaList";
import { aviso, sucesso } from "../utils/Alerts";

function CategoriasPage(){

    const [descricao, setDescricao] = useState("");
    const [finalidade, setFinalidade] = useState<"Receita" | "Despesa" | "Ambas">("Despesa");

    const [categorias, setCategorias] = useState<Categoria[]>([]);
    const [modalAberto, setModalAberto] = useState(false);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        carregarCategorias();
    }, []);

    async function carregarCategorias(){

        try{

            setLoading(true);

            const data = await getCategorias();

            setCategorias(data);

        }catch(error){

            console.error("Erro ao carregar categorias", error);

        }finally{

            setLoading(false);

        }
    }

    async function salvarCategoria(){

        if(!descricao){
            aviso("Informe a descrição da categoria");
            return;
        }

        try{

            await createCategoria(descricao, finalidade);

            setDescricao("");
            setFinalidade("Despesa");

            setModalAberto(false);
            sucesso("Categoria criada com sucesso");
            await carregarCategorias();

        }catch(error){
            console.error(error);
        }
    }

    return(
        <Layout>

            <div className="flex justify-between items-center mb-6">

                <h1 className="text-3xl font-bold text-indigo-600">
                    Categorias
                </h1>

                <button
                    onClick={() => setModalAberto(true)}
                    className="bg-indigo-600 text-white px-4 py-2 rounded hover:bg-indigo-500"
                >
                    Nova Categoria
                </button>

            </div>

            {loading ? (

                <div className="text-center text-gray-500">
                    Carregando categorias...
                </div>

            ) : (

                <CategoriaList categorias={categorias} />

            )}

            <Modal
                aberto={modalAberto}
                fechar={() => setModalAberto(false)}
            >

                <h2 className="text-xl font-semibold mb-4">
                    Nova Categoria
                </h2>

                <div className="space-y-4">

                    <input
                        className="w-full border border-gray-300 rounded-lg p-2 focus:outline-none focus:ring-2 focus:ring-indigo-500"
                        placeholder="Descrição"
                        value={descricao}
                        onChange={(e) => setDescricao(e.target.value)}
                    />

                    <select
                        className="w-full border border-gray-300 rounded-lg p-2 focus:outline-none focus:ring-2 focus:ring-indigo-500"
                        value={finalidade}
                        onChange={(e) =>
                            setFinalidade(e.target.value as "Receita" | "Despesa" | "Ambas")
                        }
                    >
                        <option value="Receita">Receita</option>
                        <option value="Despesa">Despesa</option>
                        <option value="Ambas">Ambas</option>
                    </select>

                    <button
                        onClick={salvarCategoria}
                        className="w-full bg-indigo-600 text-white py-2 rounded-lg hover:bg-indigo-500"
                    >
                        Salvar
                    </button>

                </div>

            </Modal>

        </Layout>
    );
}

export default CategoriasPage;