import { useState } from "react";
import { Link, NavLink, useNavigate } from "react-router-dom";

import logoEvent from "../../assets/logo-event.svg";
import iconeSair from "../../assets/icons/sair.svg";
import iconeMenu from "../../assets/icons/menu-bars.svg";
import "./Header.css";
import { perfilEhAdministrador, perfilEhOrganizador, useAuth } from "../../context/auth";

function Header() {
    const { autenticado, usuario, perfil, logout } = useAuth();
    const [menuAberto, setMenuAberto] = useState(false);

    const navigate = useNavigate();
    const administrador = perfilEhAdministrador(perfil);
    const organizador = perfilEhOrganizador(perfil);

    const rotuloPerfil = administrador
        ? "Administrador"
        : organizador
          ? "Organizador"
          : usuario?.idTipoUsuarioNavigation?.titulo || usuario?.nome || "Usuário";

    function sair() {
        setMenuAberto(false);
        logout();
        navigate("/login");
    }

    function fecharMenu() {
        setMenuAberto(false);
    }

    return (
        <header className="header">
            <div className="header-conteudo">
                <Link className="header-logo-link" to="/home" onClick={fecharMenu}>
                    <img src={logoEvent} alt="Logo Event+" />
                </Link>

                <button
                    className="header-menu-toggle"
                    type="button"
                    aria-label={menuAberto ? "Fechar menu" : "Abrir menu"}
                    aria-expanded={menuAberto}
                    onClick={() => setMenuAberto((aberto) => !aberto)}
                >
                    <img src={iconeMenu} alt="" />
                </button>

                <div className={`header-navegacao-area ${menuAberto ? "header-navegacao-aberta" : ""}`}>
                    <nav className="header-nav" aria-label="Navegação principal">
                        <NavLink to="/home" onClick={fecharMenu}>
                            Home
                        </NavLink>
                        <NavLink to="/eventos" onClick={fecharMenu}>
                            Eventos
                        </NavLink>
                        {administrador ? (
                            <NavLink to="/admin" onClick={fecharMenu}>
                                Admin
                            </NavLink>
                        ) : null}
                        <Link to="/home#contato" onClick={fecharMenu}>
                            Contatos
                        </Link>
                    </nav>

                    <div className="header-usuario">
                        {autenticado ? (
                            <>
                                {administrador ? (
                                    <Link
                                        className="header-usuario-perfil"
                                        to="/admin"
                                        onClick={fecharMenu}
                                        title="Acessar Painel do Administrador"
                                    >
                                        {rotuloPerfil}
                                    </Link>
                                ) : (
                                    <span className="header-usuario-perfil">{rotuloPerfil}</span>
                                )}
                                <button
                                    className="header-botao-sair"
                                    type="button"
                                    onClick={sair}
                                    aria-label="Sair da conta"
                                    title="Sair"
                                >
                                    <img src={iconeSair} alt="Sair" />
                                </button>
                            </>
                        ) : (
                            <Link className="header-link-entrar" to="/login" onClick={fecharMenu}>
                                Entrar
                            </Link>
                        )}
                    </div>
                </div>
            </div>
        </header>
    );
}

export default Header;
