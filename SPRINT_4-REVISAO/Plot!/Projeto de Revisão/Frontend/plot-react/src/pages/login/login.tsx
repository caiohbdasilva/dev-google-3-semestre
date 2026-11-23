import { useState } from "react";
import axios from "axios";
import Logo from "../../assets/Logo vetorizado - claro.svg"
import "./login.css"
import { useNavigate } from "react-router-dom";
import { fazerLogin } from "../../api/autenticacao";
import { salvarSessao } from "../../services/sessaoService";


function Login() {

    //Cria um estado para armazenar e atualizar um email e senha;
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");

    // console.log("Email", email);
    // console.log("Senha", senha);
    
    // Hook do React Router que permite navegar entre as páginas
    const navigate = useNavigate();

    // Estado para armazenar mensagens de erro
    const [erro, setErro] = useState("");
    //Estado para controlar carregamento durante o login
    const [carregando, setCarregando] = useState(false);

    //função assincrona responsável por gerenciar o login
    //async: permite executar sem bloquear a execução do restante da aplicação
    async function gerenciarLogin(evento: React.SubmitEvent<HTMLFormElement>) {
        // impede o comportamento padrão do envio do formulário (recarregar a página)
        evento.preventDefault();
        setErro(""); //Limpa mensagens de erro anteriores
        setCarregando(true); //Indica que o processo de login foi iniciado

        //tenta executar o login e trata o erro
        try {
        //await: pausa a execução daquela função assíncrona até que a operação seja concluída.
        //Aguarda a resposta da API com os dados do usuário 
            const resposta = await fazerLogin(email,senha);
            salvarSessao(resposta); // salva os dados recebidos na sessão
            //redireciona para home, substituindo a página atual no histórico
            //replace: true -> substitui a entrada atual do histórico de navegação
            navigate("/home", {replace: true}); 

        } catch (error) {
            console.error("Erro ao realizar o login", error);
            if (axios.isAxiosError(error) && !error.response) {
                setErro("Não foi possível conectar ao servidor.");
            } else if (axios.isAxiosError(error) && error.response?.status === 401) {
                setErro("E-mail ou senha inválidos.");
            } else {
                setErro("Não foi possível realizar o login.");
            }
        } finally {
            // finaliza o estado de carregamento, mesmo se ocorrer erro.
            setCarregando(false);
        }
    }

    return(
        <>
        <main className="area-login">

            <section className="conteudo-login">

                <img className="logo" src={Logo} alt="Plot!" />

                <p className="descricao">Crie suas listas, marque o que já assistiu e descubra novas histórias.</p>

                <form onSubmit={gerenciarLogin}>

                    <div className="campo">
                        <i className="fa-solid fa-envelope"></i>
                        <input type="email" name="email" placeholder="exemplo@email.com" 
                        value={email} 
                        //Atualiza o estado do email conforme o usuario digita
                        //evento -> evento de alteração
                        //evento.target -> input type=email
                        //evento.target.value -> email digitado pelo usuário
                        onChange={(evento) => setEmail(evento.target.value)}/>
                    </div>

                    <div className="campo">
                        <i className="fa-solid fa-lock"></i>
                        <input type="password" name="senha" placeholder="Digite sua senha" value={senha} onChange={(evento) => setSenha(evento.target.value)}/>
                    </div>


                    {/* Exibe a mensagem de erro somente se existir um erro */}
                    {/* Renderização condicional: operador &&(E) -> se existir uma mensagem de erro, mostra na tela */}
                    {erro && <p className="erro-login">{erro}</p>}

                    <div className="opcoes-login">

                        <label className="lembrar">
                            <input type="checkbox" name="lembrar" />
                            <span>Lembrar de mim</span>
                        </label>

                        <a href="#">Esqueceu a senha?</a>

                    </div>

                    <button type="submit" className="botao-entrar" disabled={carregando}>{carregando ? "Entrando..." : "Entrar"}</button>

                </form>

                <p className="mensagem-cadastro">Ainda não tem uma conta? <a href="#">Contate um administrador</a></p>

            </section>

        </main>
        </>
    );
}

export default Login;