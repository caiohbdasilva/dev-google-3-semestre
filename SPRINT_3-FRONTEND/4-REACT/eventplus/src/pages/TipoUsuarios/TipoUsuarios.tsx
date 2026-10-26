import { useCallback, useEffect, useState, type FormEvent } from "react";
import Header from "../../components/header/Header";
import Footer from "../../components/footer/Footer";
import Campo from "../../components/campo/Campo";
import Botao from "../../components/botao/Botao";
import ListaTipos, { type ItemTipo } from "../../components/listaTipos/ListaTipos";
import ModalConfirmacao from "../../components/modalConfirmacao/ModalConfirmacao";
import { tipoUsuarioService } from "../../services/eventPlusservice";
import { getApiErrorMessage } from "../../services/api";
import type { TipoUsuario } from "../../types/api";

import tipoUsuarioImg from "../../assets/tipo-usuario-img.svg";
import "./TipoUsuarios.css";

function TipoUsuarios() {
    const [titulo, setTitulo] = useState("");
    const [tipos, setTipos] = useState<TipoUsuario[]>([]);
    const [idEmEdicao, setIdEmEdicao] = useState<string | null>(null);
    const [selecionado, setSelecionado] = useState<ItemTipo | null>(null);
    const [carregando, setCarregando] = useState(true);
    const [enviando, setEnviando] = useState(false);
    const [mensagem, setMensagem] = useState("");

    const carregar = useCallback(async () => {
        setCarregando(true);
        setMensagem("");
        try {
            const dados = await tipoUsuarioService.listar();
            setTipos(dados);
        } catch (error) {
            setMensagem(getApiErrorMessage(error));
        } finally {
            setCarregando(false);
        }
    }, []);

    useEffect(() => {
        const timeout = window.setTimeout(() => void carregar(), 0);
        return () => window.clearTimeout(timeout);
    }, [carregar]);

    function limpar() {
        setTitulo("");
        setIdEmEdicao(null);
        setMensagem("");
    }

    async function salvar(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();
        const tituloLimpo = titulo.trim();
        if (!tituloLimpo) return;

        setEnviando(true);
        setMensagem("");
        try {
            if (idEmEdicao) {
                await tipoUsuarioService.atualizar(idEmEdicao, tituloLimpo);
            } else {
                await tipoUsuarioService.cadastrar(tituloLimpo);
            }
            limpar();
            await carregar();
        } catch (error) {
            setMensagem(getApiErrorMessage(error));
        } finally {
            setEnviando(false);
        }
    }

    function editar(item: ItemTipo) {
        setIdEmEdicao(item.id);
        setTitulo(item.titulo);
        setMensagem("");
        window.scrollTo({ top: 0, behavior: "smooth" });
    }

    async function excluir() {
        if (!selecionado) return;
        setEnviando(true);
        try {
            await tipoUsuarioService.excluir(selecionado.id);
            if (idEmEdicao === selecionado.id) limpar();
            setSelecionado(null);
            await carregar();
        } catch (error) {
            setMensagem(getApiErrorMessage(error));
            setSelecionado(null);
        } finally {
            setEnviando(false);
        }
    }

    const itensLista: ItemTipo[] = tipos.map((tipo) => ({
        id: tipo.idTipoUsuario,
        titulo: tipo.titulo,
    }));

    return (
        <>
            <Header />
            <main className="cadastro-tipo-usuario-page">
                <section className="cadastro-tipo-usuario-formulario-section">
                    <div className="cadastro-tipo-usuario-titulo">
                        <h1>ADMINISTRAÇÃO TIPO DE USUÁRIOS</h1>
                        <hr />
                    </div>

                    <div className="cadastro-tipo-usuario-conteudo">
                        <img
                            className="cadastro-tipo-usuario-ilustracao"
                            src={tipoUsuarioImg}
                            alt="Ilustração da administração de tipo de usuários"
                        />

                        <form className="cadastro-tipo-usuario-formulario" onSubmit={salvar}>
                            <div className="cadastro-tipo-usuario-campo-wrapper">
                                <label className="visually-hidden" htmlFor="tipo-usuario-titulo">
                                    Título
                                </label>
                                <Campo
                                    id="tipo-usuario-titulo"
                                    name="titulo"
                                    type="text"
                                    value={titulo}
                                    onChange={(event) => setTitulo(event.target.value)}
                                    placeholder="Titulo"
                                    maxLength={100}
                                    required
                                />
                            </div>

                            <Botao
                                className="cadastro-tipo-usuario-botao"
                                texto={enviando ? "Salvando..." : idEmEdicao ? "Salvar" : "Cadastrar"}
                                type="submit"
                                disabled={enviando}
                            />

                            {idEmEdicao ? (
                                <button
                                    className="cadastro-tipo-usuario-cancelar"
                                    type="button"
                                    onClick={limpar}
                                >
                                    Cancelar Edição
                                </button>
                            ) : null}

                            {mensagem ? (
                                <p className="cadastro-tipo-usuario-mensagem" role="alert">
                                    {mensagem}
                                </p>
                            ) : null}
                        </form>
                    </div>
                </section>

                <ListaTipos
                    tituloSecao="LISTA TIPO DE USUÁRIOS"
                    itens={itensLista}
                    idEmEdicao={idEmEdicao}
                    carregando={carregando}
                    mensagemVazia="Nenhum tipo de usuário cadastrado"
                    onEditar={editar}
                    onExcluir={setSelecionado}
                />

                <ModalConfirmacao
                    show={Boolean(selecionado)}
                    titulo="Excluir tipo de usuário"
                    mensagem={selecionado ? `Deseja excluir "${selecionado.titulo}"?` : ""}
                    textoConfirmar={enviando ? "Excluindo..." : "Excluir"}
                    textoCancelar="Cancelar"
                    onClose={() => setSelecionado(null)}
                    onConfirm={() => void excluir()}
                />
            </main>
            <Footer />
        </>
    );
}

export default TipoUsuarios;
