import { BrowserRouter, Route, Routes } from "react-router-dom"
import Login from "./pages/login/login"
import Home from "./pages/Home/Home"
import RotaProtegida from "./routes/RotaProtegida"

function App() {

  return (
    //habilita a navegação entre paginas
    <BrowserRouter>
    {/* agrupa as rotas da aplicação*/}
      <Routes>
        {/* Route: Associa um endereço a um componente
        Path: Define o endereço da página
        Element: Define qual componente será exibido */}
        <Route path="/" element={<Login/>}/>
        <Route element={<RotaProtegida/>}>
          <Route path="/home" element={<Home/>}/>
        </Route>
      </Routes>
    </BrowserRouter>
  )
}

export default App
