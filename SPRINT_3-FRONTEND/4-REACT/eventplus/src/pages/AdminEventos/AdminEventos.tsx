import { useCallback, useEffect, useRef, useState, type ChangeEvent, type FormEvent } from "react";
import Header from "../../components/header/Header";
import Footer from "../../components/footer/Footer";
import Campo from "../../components/campo/Campo";
import Botao from "../../components/botao/Botao";
import CardEvento from "../../components/cardEvento/CardEvento";
import { eventoService, instituicaoService, tipoEventoService } from "../../services/eventPlusservice";
import { getApiErrorMessage } from "../../services/api";
import type { Evento, instituicao, TipoEvento } from "../../types/api";

import adminEventoImg from "../../assets/admin-evento-img.svg";
import iconeRelogio from "../../assets/icons/relogio.svg";
import iconeUpload from "../../assets/icons/upload.svg";
import "./AdminEventos.css";

interface FormularioEvento {
    nome: string;
    dataEvento: string;
    descricao: string;
    idTipoEvento: string;
    idInstituicao: string;
}

const inicial: FormularioEvento = {
    nome: "",
    dataEvento: "",
    descricao: "",
    idTipoEvento: "",
    idInstituicao: "",
};

function AdminEventos() {
    const [formulario, setFormulario] = useState<FormularioEvento>(inicial);
    const [arquivoImagem, setArquivoImagem] = useState<File | null>(null);
    const [eventos, setEventos] = useState<Evento[]>([]);
    const [tiposEvento, setTiposEvento] = useState<TipoEvento[]>([]);
    const [instituicoes, setInstituicoes] = useState<instituicao[]>([]);
    const [carregando, setCarregando] = useState(true);
    const [enviando, setEnviando] = useState(false);
    const [mensagem, setMensagem] = useState("");
    const fileInputRef = useRef<HTMLInputElement | null>(null);

    const carregar = useCallback(async () => {
        setCarregando(true);
        setMensagem("");
        try {
            const [eventosApi, tiposApi, instituicoesApi] = await Promise.all([
                eventoService.listar(),
                tipoEventoService.listar(),
                instituicaoService.listar(),
            ]);
            setEventos(eventosApi);
            setTiposEvento(tiposApi);
            setInstituicoes(instituicoesApi);
            setFormulario((atual) => ({
                ...atual,
                idTipoEvento: atual.idTipoEvento || tiposApi[0]?.idTipoEvento || "",
                idInstituicao: atual.idInstituicao || instituicoesApi[0]?.idInstituicao || "",
            }));
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

    function atualizar(event: ChangeEvent<HTMLInputElement | HTMLSelectElement>) {
        const { name, value } = event.target;
        setFormulario((atual) => ({ ...atual, [name]: value }));
    }

    function selecionarArquivo(event: ChangeEvent<HTMLInputElement>) {
        const file = event.target.files?.[0] ?? null;
        setArquivoImagem(file);
    }

    function limpar() {
        setFormulario({
            ...inicial,
            idTipoEvento: tiposEvento[0]?.idTipoEvento || "",
            idInstituicao: instituicoes[0]?.idInstituicao || "",
        });
        setArquivoImagem(null);
        if (fileInputRef.current) fileInputRef.current.value = "";
    }

    async function salvar(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();
        setEnviando(true);
        setMensagem("");

        try {
            const formData = new FormData();
            formData.append("Nome", formulario.nome.trim());
            formData.append("Descricao", formulario.descricao.trim());
            formData.append("DataEvento", formulario.dataEvento);
            if (formulario.idTipoEvento) {
                formData.append("IdTipoEvento", formulario.idTipoEvento);
            }
            if (formulario.idInstituicao) {
                formData.append("IdInstituicao", formulario.idInstituicao);
            }
            if (arquivoImagem) {
                formData.append("ArquivoImagem", arquivoImagem);
            }

            await eventoService.cadastrar(formData);
            limpar();
            await carregar();
            setMensagem("Evento cadastrado com sucesso.");
        } catch (error) {
            setMensagem(getApiErrorMessage(error));
        } finally {
            setEnviando(false);
        }
    }

    return (
        <>
            <Header />
            <main className="admin-evento-page">
                <section className="admin-evento-formulario-section">
                    <div className="admin-evento-titulo">
                        <h1>ADMINISTRAÇÃO EVENTO</h1>
                        <hr />
                    </div>

                    <div className="admin-evento-conteudo">
                        <img
                            className="admin-evento-ilustracao"
                            src={adminEventoImg}
                            alt="Ilustração da administração de eventos"
                        />

                        <form className="admin-evento-formulario" onSubmit={salvar}>
                            <div className="admin-evento-linha-topo">
                                <div className="admin-evento-campo-nome">
                                    <label className="visually-hidden" htmlFor="evento-nome">
                                        Nome
                                    </label>
                                    <Campo
                                        id="evento-nome"
                                        name="nome"
                                        type="text"
                                        value={formulario.nome}
                                        onChange={atualizar}
                                        placeholder="Nome"
                                        maxLength={100}
                                        required
                                    />
                                </div>

                                <div className="admin-evento-campo-data">
                                    <label className="visually-hidden" htmlFor="evento-data">
                                        Data e hora do evento
                                    </label>
                                    <img src={iconeRelogio} alt="" />
                                    <input
                                        id="evento-data"
                                        name="dataEvento"
                                        type="datetime-local"
                                        value={formulario.dataEvento}
                                        onChange={atualizar}
                                        required
                                    />
                                </div>
                            </div>

                            <div className="admin-evento-campo-largo">
                                <label className="visually-hidden" htmlFor="evento-descricao">
                                    Descrição
                                </label>
                                <Campo
                                    id="evento-descricao"
                                    name="descricao"
                                    type="text"
                                    value={formulario.descricao}
                                    onChange={atualizar}
                                    placeholder="Descrição"
                                    required
                                />
                            </div>

                            <div className="admin-evento-linha-selects">
                                <div className="admin-evento-select-wrapper">
                                    <label className="visually-hidden" htmlFor="evento-tipo">
                                        Tipo de Evento
                                    </label>
                                    <select
                                        id="evento-tipo"
                                        name="idTipoEvento"
                                        value={formulario.idTipoEvento}
                                        onChange={atualizar}
                                        required
                                    >
                                        <option value="" disabled>
                                            Tipo de Evento
                                        </option>
                                        {tiposEvento.map((tipo) => (
                                            <option key={tipo.idTipoEvento} value={tipo.idTipoEvento}>
                                                {tipo.titulo}
                                            </option>
                                        ))}
                                    </select>
                                </div>

                                <div className="admin-evento-select-wrapper">
                                    <label className="visually-hidden" htmlFor="evento-instituicao">
                                        Instituição
                                    </label>
                                    <select
                                        id="evento-instituicao"
                                        name="idInstituicao"
                                        value={formulario.idInstituicao}
                                        onChange={atualizar}
                                        required
                                    >
                                        <option value="" disabled>
                                            Instituição
                                        </option>
                                        {instituicoes.map((inst) => (
                                            <option key={inst.idInstituicao} value={inst.idInstituicao}>
                                                {inst.nomeFantasia}
                                            </option>
                                        ))}
                                    </select>
                                </div>
                            </div>

                            <div className="admin-evento-campo-foto">
                                <label htmlFor="evento-foto">
                                    <span>{arquivoImagem ? arquivoImagem.name : "Foto"}</span>
                                    <img src={iconeUpload} alt="Enviar foto" />
                                </label>
                                <input
                                    ref={fileInputRef}
                                    id="evento-foto"
                                    type="file"
                                    accept="image/*"
                                    onChange={selecionarArquivo}
                                />
                            </div>

                            <Botao
                                className="admin-evento-botao"
                                texto={enviando ? "Cadastrando..." : "Cadastrar"}
                                type="submit"
                                disabled={enviando}
                            />

                            {mensagem ? (
                                <p className="admin-evento-mensagem" role="status">
                                    {mensagem}
                                </p>
                            ) : null}
                        </form>
                    </div>
                </section>

                <section className="admin-evento-lista-section">
                    <div className="admin-evento-titulo admin-evento-subtitulo">
                        <h2>EVENTOS</h2>
                        <hr />
                    </div>

                    {carregando ? <p className="admin-evento-status">Carregando eventos...</p> : null}
                    {!carregando && eventos.length === 0 ? (
                        <p className="admin-evento-status">Nenhum evento cadastrado.</p>
                    ) : null}

                    <div className="admin-evento-cards">
                        {eventos.map((evento) => (
                            <CardEvento
                                key={evento.idEvento}
                                id={evento.idEvento}
                                titulo={evento.nome}
                                descricao={evento.descricao}
                                imagem={evento.imagemUrl}
                                categoria={evento.idTipoEventoNavigation?.titulo}
                            />
                        ))}
                    </div>
                </section>
            </main>
            <Footer />
        </>
    );
}

export default AdminEventos;
