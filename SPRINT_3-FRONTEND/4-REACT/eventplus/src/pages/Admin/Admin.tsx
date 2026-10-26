import { Link } from "react-router-dom";
import Header from "../../components/header/Header";
import Footer from "../../components/footer/Footer";
import { useAuth } from "../../context/auth";

import adminEventoImg from "../../assets/admin-evento-img.svg";
import adminUsuarioImg from "../../assets/admin-usuario-img.svg";
import tipoEventoImg from "../../assets/tipo-evento-img.svg";
import tipoUsuarioImg from "../../assets/tipo-usuario-img.svg";
import "./Admin.css";

const modulosAdmin = [
    {
        id: "admin-eventos",
        titulo: "Administração de Eventos",
        categoria: "Eventos",
        descricao: "Cadastre novos eventos com data, instituição, categoria e foto de capa.",
        rota: "/admin-eventos",
        imagem: adminEventoImg,
    },
    {
        id: "admin-usuarios",
        titulo: "Administração de Usuários",
        categoria: "Usuários",
        descricao: "Gerencie os usuários cadastrados, atribua perfis de acesso e atualize credenciais.",
        rota: "/usuarios",
        imagem: adminUsuarioImg,
    },
    {
        id: "admin-tipo-eventos",
        titulo: "Tipo de Eventos",
        categoria: "Categorias",
        descricao: "Crie, edite e exclua as categorias utilizadas na classificação dos eventos.",
        rota: "/tipo-eventos",
        imagem: tipoEventoImg,
    },
    {
        id: "admin-tipo-usuarios",
        titulo: "Tipo de Usuários",
        categoria: "Perfis",
        descricao: "Administre os tipos de perfil do sistema (Administrador, Aluno, Palestrante, etc.).",
        rota: "/tipo-usuarios",
        imagem: tipoUsuarioImg,
    },
];

function Admin() {
    const { usuario } = useAuth();

    return (
        <>
            <Header />
            <main className="admin-painel-page">
                <section className="admin-painel-section">
                    <div className="admin-painel-titulo">
                        <h1>PAINEL DO ADMINISTRADOR</h1>
                        <hr />
                        <p>
                            Bem-vindo(a), <strong>{usuario?.nome || "Administrador"}</strong>. Acesse abaixo as telas administrativas disponíveis para o seu perfil:
                        </p>
                    </div>

                    <div className="admin-painel-grid">
                        {modulosAdmin.map((modulo) => (
                            <article key={modulo.id} className="admin-painel-card">
                                <div className="admin-painel-card-ilustracao">
                                    <img src={modulo.imagem} alt={modulo.titulo} />
                                </div>
                                <span className="admin-painel-card-badge">{modulo.categoria}</span>
                                <div className="admin-painel-card-corpo">
                                    <h2>{modulo.titulo}</h2>
                                    <p>{modulo.descricao}</p>
                                    <Link className="admin-painel-card-link" to={modulo.rota}>
                                        Acessar tela
                                    </Link>
                                </div>
                            </article>
                        ))}
                    </div>
                </section>
            </main>
            <Footer />
        </>
    );
}

export default Admin;
