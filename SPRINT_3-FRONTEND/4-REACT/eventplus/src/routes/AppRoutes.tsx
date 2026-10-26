import type { PropsWithChildren } from "react";
import { Navigate, Route, Routes, useLocation } from "react-router-dom";

import Home from "../pages/Home/Home";
import Eventos from "../pages/Eventos/Eventos";
import DetalhesEvento from "../pages/DetalhesEvento/DetalhesEvento";
import Login from "../pages/Login/Login";
import Usuarios from "../pages/Usuarios/Usuarios";
import TipoEventos from "../pages/TipoEventos/TipoEventos";
import TipoUsuarios from "../pages/TipoUsuarios/TipoUsuarios";
import Admin from "../pages/Admin/Admin";
import AdminEventos from "../pages/AdminEventos/AdminEventos";
import { perfilEhAdministrador, useAuth } from "../context/auth";

function RotaAdmin({ children }: PropsWithChildren) {
    const { autenticado, perfil, carregandoSessao } = useAuth();
    const location = useLocation();

    if (carregandoSessao) {
        return null;
    }

    if (!autenticado) {
        return <Navigate to="/login" state={{ from: location.pathname }} replace />;
    }

    if (!perfilEhAdministrador(perfil)) {
        return <Navigate to="/home" replace />;
    }

    return <>{children}</>;
}

function AppRoutes() {
    return (
        <Routes>
            <Route path="/home" element={<Home />} />

            <Route path="/eventos" element={<Eventos />} />

            <Route path="/eventos/:id" element={<DetalhesEvento />} />

            <Route
                path="/admin"
                element={
                    <RotaAdmin>
                        <Admin />
                    </RotaAdmin>
                }
            />

            <Route
                path="/admin-eventos"
                element={
                    <RotaAdmin>
                        <AdminEventos />
                    </RotaAdmin>
                }
            />

            <Route
                path="/tipo-eventos"
                element={
                    <RotaAdmin>
                        <TipoEventos />
                    </RotaAdmin>
                }
            />
            <Route
                path="/tipos-eventos"
                element={
                    <RotaAdmin>
                        <TipoEventos />
                    </RotaAdmin>
                }
            />

            <Route
                path="/tipo-usuarios"
                element={
                    <RotaAdmin>
                        <TipoUsuarios />
                    </RotaAdmin>
                }
            />
            <Route
                path="/tipos-usuarios"
                element={
                    <RotaAdmin>
                        <TipoUsuarios />
                    </RotaAdmin>
                }
            />

            <Route path="/login" element={<Login />} />

            <Route
                path="/usuarios"
                element={
                    <RotaAdmin>
                        <Usuarios />
                    </RotaAdmin>
                }
            />

            <Route path="*" element={<Navigate to="/home" replace />} />
        </Routes>
    );
}

export default AppRoutes;
