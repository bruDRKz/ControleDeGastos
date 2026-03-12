import './App.css'
import { BrowserRouter, Routes, Route } from "react-router-dom";

import Navbar from "./components/Navbar";

import PessoasPage from "./pages/PessoasPage";
import DashboardPage from "./pages/DashboardPage";
import CategoriasPage from './pages/CategoriasPage';

function App() {
  return (
    <BrowserRouter>

      <Navbar />

      <div className="min-h-screen bg-slate-100">
        <Routes>
          <Route path="/pessoas" element={<PessoasPage />} />
          <Route path="/dashboard" element={<DashboardPage />} />
          <Route path='/categorias' element={<CategoriasPage />}></Route>
        </Routes>
      </div>

    </BrowserRouter>
  );
}

export default App;