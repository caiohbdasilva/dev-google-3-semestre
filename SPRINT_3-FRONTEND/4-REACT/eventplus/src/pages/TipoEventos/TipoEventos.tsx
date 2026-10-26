import { useCallback, useEffect, useState, type FormEvent } from "react";
import Header from "../../components/header/Header";
import Footer from "../../components/footer/Footer";
import Campo from "../../components/campo/Campo";
import Botao from "../../components/botao/Botao";
import ListaTipos, { type ItemTipo } from "../../components/listaTipos/ListaTipos";
import ModalConfirmacao from "../../components/modalConfirmacao/ModalConfirmacao";
import { tipoEventoService } from "../../services/eventPlusservice";
import { getApiErrorMessage } from "../../services/api";
import type { TipoEvento } from "../../types/api";

import tipoEventoImg from "../../assets/tipo-evento-img.svg";
import "./TipoEventos.css";

function TipoEventos() {
    const [titulo, setTitulo] = useState("");
    const [tipos, setTipos] = useState<TipoEvento[]>([]);
    const [idEmEdicao, setIdEmEdicao] = useState<string | null>(null);
    const [selecionado, setSelecionado] = useState<ItemTipo | null>(null);
    const [carregando, setCarregando] = useState(true);
    const [enviando, setEnviando] = useState(false);
    const [mensagem, setMensagem] = useState("");

    const carregar = useCallback(async () => {
        setCarregando(true);
        setMensagem("");
        try {
            const dados = await tipoEventoService.listar();
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
                await tipoEventoService.atualizar(idEmEdicao, tituloLimpo);
            } else {
                await tipoEventoService.cadastrar(tituloLimpo);
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
            await tipoEventoService.excluir(selecionado.id);
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
        id: tipo.idTipoEvento,
        titulo: tipo.titulo,
    }));

    return (
        <>
            <Header />
            <main className="cadastro-tipo-page">
                <section className="cadastro-tipo-formulario-section">
                    <div className="cadastro-tipo-titulo">
                        <h1>ADMINISTRAÇÃO TIPO DE EVENTOS</h1>
                        <hr />
                    </div>

                    <div className="cadastro-tipo-conteudo">
                        <img
                            className="cadastro-tipo-ilustracao cadastro-tipo-evento-ilustracao"
                            src={tipoEventoImg}
                            alt="Ilustração da administração de tipo de eventos"
                        />

                        <form className="cadastro-tipo-formulario" onSubmit={salvar}>
                            <div className="cadastro-tipo-campo-wrapper">
                                <label className="visually-hidden" htmlFor="tipo-evento-titulo">
                                    Título
                                </label>
                                <Campo
                                    id="tipo-evento-titulo"
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
                                className="cadastro-tipo-botao"
                                texto={enviando ? "Salvando..." : idEmEdicao ? "Salvar" : "Cadastrar"}
                                type="submit"
                                disabled={enviando}
                            />

                            {idEmEdicao ? (
                                <button
                                    className="cadastro-tipo-cancelar"
                                    type="button"
                                    onClick={limpar}
                                >
                                    Cancelar Edição
                                </button>
                            ) : null}

                            {mensagem ? (
                                <p className="cadastro-tipo-mensagem" role="alert">
                                    {mensagem}
                                </p>
                            ) : null}
                        </form>
                    </div>
                </section>

                <ListaTipos
                    tituloSecao="LISTA TIPO DE EVENTOS"
                    itens={itensLista}
                    idEmEdicao={idEmEdicao}
                    carregando={carregando}
                    mensagemVazia="Nenhum tipo de evento cadastrado"
                    onEditar={editar}
                    onExcluir={setSelecionado}
                />

                <ModalConfirmacao
                    show={Boolean(selecionado)}
                    titulo="Excluir tipo de evento"
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

export default TipoEventos;
