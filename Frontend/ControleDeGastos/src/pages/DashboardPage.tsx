import { useEffect, useState } from "react";
import { getTransacoes } from "../services/transacaoService";
import { getResumo, type ResumoResponse } from "../services/resumoService";
import { getPessoas } from "../services/pessoaService";
import { getCategorias } from "../services/categoriaService";
import SummaryCards from "../components/SummaryCards";
import TransactionTable from "../components/TransactionTable"
import Modal from "../components/Modal"
import TransactionForm from "../components/TransactionForm"
import Layout from "../components/Layout";
import type { Pessoa } from "../types/Pessoa";
import type { Categoria } from "../types/Categoria";
import type { Transacao } from "../types/Transacao";

function DashboardPage() {

    const [transacoes, setTransacoes] = useState<Transacao[]>([]);
    const [resumo, setResumo] = useState<ResumoResponse | null>(null);
    const [pessoas, setPessoas] = useState<Pessoa[]>([]);
    const [categorias, setCategorias] = useState<Categoria[]>([])
    const [modalAberto, setModalAberto] = useState(false)

    useEffect(() => {
        carregarDados();
    }, []);

    async function carregarDados() {

    try {

        const [
            transacoesData,
            resumoData,
            pessoasData,
            categoriasData
        ] = await Promise.all([
            getTransacoes(),
            getResumo(),
            getPessoas(),
            getCategorias()
        ]);

        setTransacoes(transacoesData);
        setResumo(resumoData);
        setPessoas(pessoasData);
        setCategorias(categoriasData);        

    } catch (error) {
        console.error("Erro ao carregar dashboard", error);
    }
}

    return (
      <Layout>
        <div className="flex justify-between items-center mb-6">
          <h1 className="text-3xl font-bold text-indigo-600">
            Dashboard
          </h1>
        
          <button
            onClick={() => setModalAberto(true)}
            className="bg-indigo-600 text-white px-4 py-2 rounded hover:bg-indigo-500">
            Nova Transação
          </button>
        </div>
        
        {resumo && (
          <SummaryCards
            totalReceitas={resumo.totalReceitas}
            totalDespesas={resumo.totalDespesas}
            saldo={resumo.saldo}/>
        )}
    
        <h2 className="text-xl font-semibold mb-4 mt-6">
          Histórico de Transações
        </h2>
    
        <TransactionTable
          transacoes={transacoes}
          pessoas={pessoas}
          categorias={categorias}
        />
    
        <Modal aberto={modalAberto} fechar={() => setModalAberto(false)}>
          <TransactionForm          
            pessoas={pessoas}
            categorias={categorias}
            onSucesso={() => {
              setModalAberto(false);
              carregarDados();
            }}
          />
        </Modal>
      </Layout>
    );
}

export default DashboardPage;