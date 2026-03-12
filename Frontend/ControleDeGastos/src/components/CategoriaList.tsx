import type { Categoria } from "../types/Categoria";

type CategoriaListProps = {
    categorias: Categoria[];
};

function CategoriaList({ categorias }: CategoriaListProps) {

    if (categorias.length === 0) {
        return (
            <div className="text-center text-gray-500">
                Nenhuma categoria cadastrada
            </div>
        );
    }

    return (
        <div className="space-y-3">

            {categorias.map(categoria => (

                <div
                    key={categoria.id}
                    className="flex justify-between items-center bg-white p-4 rounded-lg shadow-sm border border-gray-200"
                >

                    <span className="font-medium">
                        {categoria.descricao}
                    </span>

                    <div className="flex items-center gap-4">

                        <span className="text-gray-600">
                            {categoria.finalidade}
                        </span>

                    </div>

                </div>

            ))}

        </div>
    );
}

export default CategoriaList;