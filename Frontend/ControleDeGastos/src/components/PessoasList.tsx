import type { Pessoa } from "../types/Pessoa";

type PessoaListProps = {
    pessoas: Pessoa[];
    onDelete: (id: number) => void;
    onEdit: (pessoa: Pessoa) => void;
}
function PessoaList({ pessoas, onDelete, onEdit }: PessoaListProps){

    if (pessoas.length === 0) {
        return (
            <div className="text-center text-gray-500">
                Nenhuma pessoa cadastrada
            </div>
        );
    }

    return (
        <div className="space-y-3">

            {pessoas.map(pessoa => (
                <div
                    key={pessoa.id}
                    className="flex justify-between items-center bg-white p-4 rounded-lg shadow-sm border border-gray-200">

                    <span className="font-medium">
                        {pessoa.nome}
                    </span>

                    <div className="flex items-center gap-4">

                        <span className="text-gray-600">
                            {pessoa.idade} anos
                        </span>
                                   
                        <button
                            onClick={() => onEdit(pessoa)}
                            className="text-blue-600 hover:text-blue-800">
                            Editar
                        </button>
                                   
                        <button
                            onClick={() => onDelete(pessoa.id)}
                            className="text-red-600 hover:text-red-800">
                            Excluir
                        </button>
                                   
                    </div>

                </div>
            ))}

        </div>
    );
}

export default PessoaList;