import { useState, useEffect } from "react";
import { aviso, erro, sucesso } from "../utils/Alerts"

type PessoaFormProps = {
    onSalvar: (nome: string, idade: number) => Promise<void>;
    nomeInicial: string | undefined;
    idadeInicial: number | undefined;
}

function PessoaForm({ onSalvar, nomeInicial, idadeInicial }: PessoaFormProps) {

    const [nome, setNome] = useState("");
    const [idade, setIdade] = useState<string | "">("");

    useEffect(() => {
        setNome(nomeInicial ?? "");
        setIdade(idadeInicial?.toString() ?? "");
    }, [nomeInicial, idadeInicial]);

    async function handleSubmit() {

        if (!nome || idade === "") {
            aviso("Preencha nome e idade!")
            return
        }

        try {

            await onSalvar(nome, Number(idade))

            sucesso("Pessoa salva com sucesso!")

            setNome("")
            setIdade("")

        } catch(error) {
            console.log(error);
            erro("Erro ao salvar pessoa.")
        }
    }

    return (

        <div className="space-y-4">

            <input
                type="text"
                placeholder="Nome"
                value={nome}
                onChange={(e) => setNome(e.target.value)}
                className="border border-gray-300 rounded px-3 py-2 w-full focus:outline-none focus:ring-2 focus:ring-indigo-500"
            />

            <input
                type="number"
                placeholder="Idade"
                value={idade}
                onChange={(e) => setIdade(e.target.value)}
                className="border border-gray-300 rounded px-3 py-2 w-full focus:outline-none focus:ring-2 focus:ring-indigo-500"
            />

            <button
                onClick={handleSubmit}
                className="bg-indigo-600 text-white px-4 py-2 rounded hover:bg-indigo-500 w-full"
            >
                Salvar
            </button>

        </div>

    );
}

export default PessoaForm;