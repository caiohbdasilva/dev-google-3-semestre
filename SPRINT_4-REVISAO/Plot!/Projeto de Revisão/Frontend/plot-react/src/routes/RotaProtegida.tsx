import { Navigate, Outlet } from "react-router-dom";
import { sessaoValida } from "../services/sessaoService";

//Componente responsavel por proteger rotas que exigem autenticação
function RotaProtegida() {
    //Verifica se existe uma sessao com token e prazo de expiracao valido
    if (!sessaoValida()) {
        //Navigate: componente do React Router que redireciona para outra rota
        //Replace: substitui a rota atual ao histórico de navegação, evitando voltar para ela
        return <Navigate to="/" replace />
    }

    return <Outlet /> // Exibe a página filha quando o acesso é permitido / Página filha(para onde a página é direcionada) de login -> Home
}

export default RotaProtegida;