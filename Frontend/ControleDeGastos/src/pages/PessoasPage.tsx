import { useState, useEffect } from "react";
import { getPessoas, createPessoa, deletePessoa, updatePessoa } from "../services/pessoaService";


import type { Pessoa } from "../types/Pessoa";

import Modal from "../components/Modal";
import PessoaList from "../components/PessoasList";
import Layout from "../components/Layout";
import PessoaForm from "../components/pessoasForm";
import { aviso, confirmacao } from "../utils/Alerts";

function PessoasPage(){

    // states do formulário
    const [nome, setNome] = useState("");
    const [idade, setIdade] = useState<string | "">(""); //Paris -> revisar isso
    const [pessoaEditando, setPessoaEditando] = useState<Pessoa | null>(null);
    // lista de pessoas
    const [pessoas, setPessoas] = useState<Pessoa[]>([]);

    // controle do modal
    const [modalAberto, setModalAberto] = useState(false);
    const [loading, setLoading] = useState(false);

    // carregar pessoas ao abrir página
    useEffect(() => {
        carregarPessoas();

    }, []);

    async function carregarPessoas() {
        try {

            setLoading(true);

            const resultado = await getPessoas();
            setPessoas(resultado);

        } catch (error) {

            console.error("Erro ao carregar pessoas: ", error);

        } finally {

            setLoading(false);

        }
    }

    async function salvarPessoa() {
        if(!nome || idade === ""){
            aviso("Preencha o campo de nome e idade!");
            return
        }

        try {
            await createPessoa(nome, Number(idade));
            setNome("");
            setIdade("");
            setModalAberto(false);
            await carregarPessoas();
            
        } catch (error) {
            console.log(error);
        }

    }

    async function removerPessoa(id: number){

        const confirmar = await confirmacao("Deseja realmente excluir essa pessoa?");
        
        if(!confirmar) return;
        
        await deletePessoa(id);
        await carregarPessoas();
    }

    async function editarPessoa(pessoa: Pessoa){
        try {
            setPessoaEditando(pessoa);
            setModalAberto(true);
        } catch (error) {
            console.log(error)
        }
    }

    return (
      <Layout>
        <div className="flex justify-between items-center mb-6">
          <h1 className="text-3xl font-bold text-indigo-600">
            Pessoas
          </h1>
        
          <button
            onClick={() => setModalAberto(true)}
            className="bg-indigo-600 text-white px-4 py-2 rounded hover:bg-indigo-500"
          >
            Nova Pessoa
          </button>
        </div>
        
        {loading ? (
          <div className="text-center text-gray-500">
            Carregando pessoas...
          </div>
        ) : (
          <PessoaList
            pessoas={pessoas}
            onDelete={removerPessoa}
            onEdit={editarPessoa}
          />
        )}
    
        <Modal
          aberto={modalAberto}
          fechar={() => {
            setModalAberto(false);
            setPessoaEditando(null);
          }}
        >
          <h2 className="text-xl font-semibold mb-4">
            {pessoaEditando ? "Editar Pessoa" : "Nova Pessoa"}
          </h2>
      
          <PessoaForm
            nomeInicial={pessoaEditando?.nome}
            idadeInicial={pessoaEditando?.idade}
            onSalvar={async (nome, idade) => {
              if (pessoaEditando) {
                await updatePessoa(pessoaEditando.id, nome, idade);
              } else {
                await createPessoa(nome, idade);
              }
          
              setModalAberto(false);
              setPessoaEditando(null);
              await carregarPessoas();
            }}
          />
        </Modal>
      </Layout>
    );
}

export default PessoasPage;