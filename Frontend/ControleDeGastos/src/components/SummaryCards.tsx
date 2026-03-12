type SummaryCardsProps = {
    totalReceitas: number
    totalDespesas: number
    saldo: number
}

function SummaryCards({ totalReceitas, totalDespesas, saldo }: SummaryCardsProps) {

    return (

        <div className="grid grid-cols-3 gap-6 mb-8">

            <div className="bg-white shadow rounded-lg p-4">
                <p className="text-gray-500 text-sm">Total de Receitas</p>
                <p className="text-green-600 text-2xl font-bold">
                    R$ {totalReceitas}
                </p>
            </div>

            <div className="bg-white shadow rounded-lg p-4">
                <p className="text-gray-500 text-sm">Total de Despesas</p>
                <p className="text-red-600 text-2xl font-bold">
                    R$ {totalDespesas}
                </p>
            </div>

            <div className="bg-white shadow rounded-lg p-4">
                <p className="text-gray-500 text-sm">Saldo da casa</p>
                <p className={`text-2xl font-bold ${saldo >= 0 ? "text-green-600" : "text-red-600"}`}>
                    R$ {saldo}
                </p>
            </div>

        </div>

    );
}

export default SummaryCards;