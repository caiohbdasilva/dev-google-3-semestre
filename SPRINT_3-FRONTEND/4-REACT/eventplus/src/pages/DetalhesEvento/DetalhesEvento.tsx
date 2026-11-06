import { useCallback, useEffect, useState, type FormEvent } from "react";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import type { Comentario, Evento, MensagemModeracao, Presenca } from "../../types/api";

import imagemPadrao from "../../assets/banner-1.png";
import enviar from "../../assets/icons/enviar.svg";
import filtro from "../../assets/icons/filtro.svg";
import predio from "../../assets/icons/predio.svg";
import relogio from "../../assets/icons/relogio.svg";

import Botao from "../../components/botao/Botao";
import Campo from "../../components/campo/Campo";
import Footer from "../../components/footer/Footer";
import Header from "../../components/header/Header";
import ModalConfirmacao from "../../components/modalConfirmacao/ModalConfirmacao";

import { useAuth } from "../../context/auth";
import { getApiErrorMessage } from "../../services/api";
import { comentarioService, eventoService, presencaService } from "../../services/eventPlusservice";
import "./DetalhesEvento.css";

function formatarDataEvento(value: string) {
    const data = new Date(value);
    if (Number.isNaN(data.getTime())) {
        return "Data não informada";
    }
    const dia = data.toLocaleDateString("pt-BR", { day: "2-digit" });
    const mes = data.toLocaleDateString("pt-BR", { month: "long" });
    const mesCapitalizado = mes.charAt(0).toUpperCase() + mes.slice(1);
    const hora = data.toLocaleTimeString("pt-BR", { hour: "2-digit", minute: "2-digit" });
    return `${dia} de ${mesCapitalizado} às ${hora}`;
}

function formatarDataComentario(value: string) {
    const data = new Date(value);
    if (Number.isNaN(data.getTime())) {
        return "";
    }
    const diaMes = data.toLocaleDateString("pt-BR", { day: "2-digit", month: "2-digit" });
    const hora = data.toLocaleTimeString("pt-BR", { hour: "2-digit", minute: "2-digit" });
    return `${diaMes} - ${hora}`;
}

function DetalhesEvento() {
    const { id = "" } = useParams();
    const navigate = useNavigate();
    const location = useLocation();

    const { autenticado, usuario } = useAuth();
    const [evento, setEvento] = useState<Evento | null>(null);
    const [comentarios, setComentarios] = useState<Comentario[]>([]);
    const [secaoComentarios, setSecaoComentarios] = useState<boolean>(false);
    const [presenca, setPresenca] = useState<Presenca | null>(null);
    const [presencaCarregada, setPresencaCarregada] = useState("");
    const [confirmandoCancelamento, setConfirmandoCancelamento] = useState(false);
    const [enviandoInscricao, setEnviandoInscricao] = useState(false);
    const [mensagemInscricao, setMensagemInscricao] = useState("");
    const [carregando, setCarregando] = useState(true);
    const [novoComentario, setNovoComentario] = useState("");
    const [mensagemComentario, setMensagemComentario] = useState("");
    const [enviandoComentario, setEnviandoComentario] = useState(false);
    const [erro, setErro] = useState("");

    const carregar = useCallback(async () => {
        if (!id) return;
        setCarregando(true);
        setErro("");
        try {
            const [eventoAtual, comentariosAtuais] = await Promise.all([
                eventoService.buscar(id),
                comentarioService.listarPorEvento(id).catch(() => [] as Comentario[]),
            ]);
            setEvento(eventoAtual);
            setComentarios(comentariosAtuais);
        } catch (error) {
            setErro(getApiErrorMessage(error));
        } finally {
            setCarregando(false);
        }
    }, [id]);

    useEffect(() => {
        const timeout = window.setTimeout(() => void carregar(), 0);
        return () => window.clearTimeout(timeout);
    }, [carregar]);

    useEffect(() => {
        if (!usuario || !id) return;
        const chave = `${usuario.idUsuario}:${id}`;
        let ativo = true;

        presencaService
            .listarPorUsuario(usuario.idUsuario)
            .then((items) => {
                if (ativo) {
                    setPresenca(items.find((item) => item.idEvento === id) ?? null);
                }
            })
            .catch(() => {
                if (ativo) setPresenca(null);
            })
            .finally(() => {
                if (ativo) setPresencaCarregada(chave);
            });

        return () => {
            ativo = false;
        };
    }, [id, usuario]);

    function exigirLogin() {
        if (autenticado) return false;
        navigate("/login", { state: { from: location.pathname } });
        return true;
    }

    async function inscrever() {
        if (exigirLogin() || !usuario || !evento || presenca) return;
        setEnviandoInscricao(true);
        setMensagemInscricao("");

        try {
            const novaPresenca = await presencaService.cadastrar({
                situacao: true,
                idEvento: evento.idEvento,
                idUsuario: usuario.idUsuario,
            });
            setPresenca(novaPresenca);
            setMensagemInscricao("Inscrição realizada com sucesso.");
        } catch (error) {
            setMensagemInscricao(getApiErrorMessage(error));
        } finally {
            setEnviandoInscricao(false);
        }
    }

    async function cancelarInscricao() {
        if (!presenca || enviandoInscricao) return;
        setEnviandoInscricao(true);
        setMensagemInscricao("");

        try {
            await presencaService.excluir(presenca.idPresenca);
            setPresenca(null);
            setMensagemInscricao("Inscrição cancelada com sucesso.");
        } catch (error) {
            setMensagemInscricao(getApiErrorMessage(error));
        } finally {
            setConfirmandoCancelamento(false);
            setEnviandoInscricao(false);
        }
    }

    async function comentar(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();
        if (exigirLogin() || !usuario || !novoComentario.trim()) return;
        setEnviandoComentario(true);
        setMensagemComentario("");

        try {
            const response = await comentarioService.cadastrar({
                descricao: novoComentario.trim(),
                idEvento: evento?.idEvento || id,
                idUsuario: usuario.idUsuario,
            });
            setNovoComentario("");
            if ("mensagem" in response) {
                setMensagemComentario((response as MensagemModeracao).mensagem);
            } else {
                setComentarios((items) => [...items, response]);
                setMensagemComentario("Comentário publicado.");
            }
        } catch (error) {
            setMensagemComentario(getApiErrorMessage(error));
        } finally {
            setEnviandoComentario(false);
        }
    }

    const chavePresenca = usuario && id ? `${usuario.idUsuario}:${id}` : "";
    const checandoPresenca = Boolean(chavePresenca && presencaCarregada !== chavePresenca);

    return (
        <>
            <Header />
            <main className="detalhe-evento-page">
                {carregando ? (
                    <div className="detalhe-evento-estado">
                        <p>Carregando detalhes do evento...</p>
                    </div>
                ) : erro ? (
                    <div className="detalhe-evento-estado">
                        <p className="detalhe-evento-mensagem">{erro}</p>
                    </div>
                ) : (
                    <section className="detalhe-evento-container">
                        <div className="detalhe-evento-banner-wrapper">
                            <img
                                className="detalhe-evento-banner"
                                src={evento?.imagemUrl || imagemPadrao}
                                alt={evento?.nome ? `Banner do evento ${evento.nome}` : "Banner do evento"}
                            />
                        </div>

                        <h1 className="detalhe-evento-titulo">{evento?.nome || "Título do Evento"}</h1>

                        <div className="detalhe-evento-grid">
                            <div className="detalhe-evento-principal">
                                <div className="detalhe-evento-abas" role="tablist" aria-label="Seções do evento">
                                    <button
                                        type="button"
                                        role="tab"
                                        aria-selected={!secaoComentarios}
                                        className={`detalhe-evento-aba ${!secaoComentarios ? "ativa" : ""}`}
                                        onClick={() => setSecaoComentarios(false)}
                                    >
                                        Sobre o evento
                                    </button>
                                    <button
                                        type="button"
                                        role="tab"
                                        aria-selected={secaoComentarios}
                                        className={`detalhe-evento-aba ${secaoComentarios ? "ativa" : ""}`}
                                        onClick={() => setSecaoComentarios(true)}
                                    >
                                        Comentários
                                    </button>
                                </div>

                                {secaoComentarios ? (
                                    <div className="detalhe-evento-comentarios" role="tabpanel">
                                        <form className="detalhe-evento-comentario-form" onSubmit={comentar}>
                                            <label className="visually-hidden" htmlFor="novo-comentario">
                                                Comentar
                                            </label>
                                            <Campo
                                                id="novo-comentario"
                                                value={novoComentario}
                                                placeholder="Comentar"
                                                maxLength={200}
                                                onChange={(event) => setNovoComentario(event.target.value)}
                                            />
                                            <button
                                                className="detalhe-evento-enviar-btn"
                                                type="submit"
                                                aria-label="Enviar comentário"
                                                disabled={enviandoComentario}
                                            >
                                                <img src={enviar} alt="Enviar" />
                                            </button>
                                        </form>

                                        {mensagemComentario ? (
                                            <p className="detalhe-evento-mensagem" role="status">
                                                {mensagemComentario}
                                            </p>
                                        ) : null}

                                        <div className="detalhe-evento-comentarios-lista">
                                            {comentarios.length === 0 ? (
                                                <p className="detalhe-evento-vazio">Nenhum comentário publicado.</p>
                                            ) : (
                                                comentarios.map((comentario) => (
                                                    <article
                                                        key={comentario.idComentario}
                                                        className="detalhe-evento-comentario"
                                                    >
                                                        <div className="detalhe-evento-comentario-topo">
                                                            <strong>
                                                                {comentario.idUsuarioNavigation?.nome ||
                                                                    (comentario.idUsuario === usuario?.idUsuario
                                                                        ? usuario?.nome
                                                                        : "Usuário")}
                                                            </strong>
                                                            <time>{formatarDataComentario(comentario.dataComentario)}</time>
                                                        </div>
                                                        <p>{comentario.descricao}</p>
                                                    </article>
                                                ))
                                            )}
                                        </div>
                                    </div>
                                ) : (
                                    <div className="detalhe-evento-sobre" role="tabpanel">
                                        <p>{evento?.descricao || "Sem descrição disponível para este evento."}</p>
                                    </div>
                                )}
                            </div>

                            <aside className="detalhe-evento-info">
                                <div className="detalhe-evento-info-titulo">
                                    <h2>INFORMAÇÕES PRINCIPAIS</h2>
                                    <hr />
                                </div>

                                <div className="detalhe-evento-info-lista">
                                    <div className="detalhe-evento-info-item">
                                        <img src={relogio} alt="" />
                                        <span>{formatarDataEvento(evento?.dataEvento || "")}</span>
                                    </div>
                                    <div className="detalhe-evento-info-item">
                                        <img src={predio} alt="" />
                                        <span>
                                            {evento?.idInstituicaoNavigation?.nomeFantasia || "SENAI Cyber & IA - São Caetano do Sul"}
                                        </span>
                                    </div>
                                    <div className="detalhe-evento-info-item">
                                        <img src={filtro} alt="" />
                                        <span>{evento?.idTipoEventoNavigation?.titulo || "Evento"}</span>
                                    </div>
                                </div>

                                <Botao
                                    className={`detalhe-evento-botao-inscricao ${presenca ? "detalhe-evento-cancelar" : ""}`}
                                    texto={
                                        checandoPresenca
                                            ? "Verificando inscrição..."
                                            : presenca
                                              ? "Cancelar Inscrição"
                                              : enviandoInscricao
                                                ? "Inscrevendo..."
                                                : "Se-inscrever"
                                    }
                                    type="button"
                                    disabled={checandoPresenca || enviandoInscricao}
                                    onClick={() =>
                                        presenca ? setConfirmandoCancelamento(true) : void inscrever()
                                    }
                                />

                                {mensagemInscricao ? (
                                    <p className="detalhe-evento-mensagem" role="status">
                                        {mensagemInscricao}
                                    </p>
                                ) : null}
                            </aside>
                        </div>
                    </section>
                )}

                <ModalConfirmacao
                    show={confirmandoCancelamento}
                    titulo="Cancelar inscrição"
                    mensagem={`Deseja cancelar sua inscrição em "${evento?.nome || "este evento"}"?`}
                    textoConfirmar={enviandoInscricao ? "Cancelando..." : "Cancelar Inscrição"}
                    textoCancelar="Manter inscrição"
                    onClose={() => {
                        if (!enviandoInscricao) setConfirmandoCancelamento(false);
                    }}
                    onConfirm={() => void cancelarInscricao()}
                />
            </main>
            <Footer />
        </>
    );
}

export default DetalhesEvento;
