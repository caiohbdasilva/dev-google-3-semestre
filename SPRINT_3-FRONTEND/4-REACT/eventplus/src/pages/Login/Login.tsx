import { useEffect, useState, type FormEvent } from "react";
import { useLocation, useNavigate } from "react-router-dom";

import logoEvent from "../../assets/logo-event.svg";
import Botao from "../../components/botao/Botao";
import Campo from "../../components/campo/Campo";
import { useAuth } from "../../context/auth";
import { getApiErrorMessage } from "../../services/api";
import "./Login.css";

function Login() {
    const navigate = useNavigate();
    const location = useLocation();
    const { login, autenticado } = useAuth();
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [erro, setErro] = useState("");
    const [enviando, setEnviando] = useState(false);

    useEffect(() => {
        if (autenticado) {
            const state = location.state as { from?: string } | null;
            navigate(state?.from || "/home", { replace: true });
        }
    }, [autenticado, location.state, navigate]);

    async function entrar(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();
        setErro("");
        setEnviando(true);

        try {
            await login({ email: email.trim(), senha });
            const state = location.state as { from?: string } | null;
            navigate(state?.from || "/home", { replace: true });
        } catch (error) {
            setErro(getApiErrorMessage(error));
        } finally {
            setEnviando(false);
        }
    }

    return (
        <main className="login-page">
            <div className="login-container">
                <img className="login-logo" src={logoEvent} alt="Logo Event+" />

                <form className="login-form" onSubmit={entrar} noValidate>
                    <div className="login-campo-grupo">
                        <label className="visually-hidden" htmlFor="login-email">
                            Login
                        </label>
                        <Campo
                            id="login-email"
                            type="email"
                            value={email}
                            onChange={(event) => setEmail(event.target.value)}
                            placeholder="Login"
                            autoComplete="email"
                            required
                        />
                    </div>

                    <div className="login-campo-grupo">
                        <label className="visually-hidden" htmlFor="login-senha">
                            Senha
                        </label>
                        <Campo
                            id="login-senha"
                            type="password"
                            value={senha}
                            onChange={(event) => setSenha(event.target.value)}
                            placeholder="Senha"
                            autoComplete="current-password"
                            minLength={4}
                            required
                        />
                    </div>

                    <p className="forgot-password">Esqueceu a senha?</p>

                    <Botao
                        className="login-botao"
                        texto={enviando ? "Entrando..." : "Entrar"}
                        type="submit"
                        disabled={enviando}
                    />

                    {erro ? (
                        <p className="login-erro" role="alert">
                            {erro}
                        </p>
                    ) : null}
                </form>
            </div>
        </main>
    );
}

export default Login;
