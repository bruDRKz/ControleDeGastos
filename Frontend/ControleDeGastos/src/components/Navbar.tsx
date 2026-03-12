import { Link } from "react-router-dom";
function Navbar(){
    return(
        <nav className="flex justify-between items-center bg-indigo-600 text-white p-4">
            <div className="font-semibold text-lg">
                Controle de Gastos APP
            </div>
            <div className="flex gap-6">                
                <Link to={"/pessoas"} className="hover:text-indigo-200">Pessoas</Link>
                <Link to={"/dashboard"} className="hover:text-indigo-200">Transações</Link>
                <Link to={"/categorias"} className="hover:text-indigo-200">Categorias</Link>                
            </div>
        </nav>
    );
}

export default Navbar;