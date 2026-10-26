import { useEffect, useMemo, useState } from "react";
import { eventoService, tipoEventoService } from "../../services/eventPlusservice";
import type { Evento, TipoEvento } from "../../types/api";

import "./Eventos.css";

import Header from "../../components/header/Header";
import Footer from "../../components/footer/Footer";
import CardEvento from "../../components/cardEvento/CardEvento";

function Eventos() {
    const [eventos, setEventos] = useState<Evento[]>([]);
    const [tiposEvento, setTiposEvento] = useState<TipoEvento[]>([]);
    const [categoriaAtiva, setCategoriaAtiva] = useState<string>("Todos");
    const [carregando, setCarregando] = useState<boolean>(true);

    useEffect(() => {
        async function carregar() {
            setCarregando(true);
            try {
                const [dadosEventos, dadosTipos] = await Promise.all([
                    eventoService.listar(),
                    tipoEventoService.listar().catch(() => [] as TipoEvento[])
                ]);
                setEventos(dadosEventos);
                setTiposEvento(dadosTipos);
            } finally {
                setCarregando(false);
            }
        }

        void carregar();
    }, []);

    const categorias = useMemo(() => {
        const nomes = new Set<string>();
        tiposEvento.forEach((tipo) => {
            if (tipo.titulo?.trim()) nomes.add(tipo.titulo.trim());
        });
        eventos.forEach((evento) => {
            const titulo = evento.idTipoEventoNavigation?.titulo?.trim();
            if (titulo) nomes.add(titulo);
        });
        return ["Todos", ...Array.from(nomes)];
    }, [eventos, tiposEvento]);

    const eventosFiltrados = useMemo(() => {
        if (categoriaAtiva === "Todos") return eventos;
        return eventos.filter(
            (evento) =>
                (evento.idTipoEventoNavigation?.titulo || "").toLowerCase() ===
                categoriaAtiva.toLowerCase()
        );
    }, [eventos, categoriaAtiva]);

    return (
        <>
            <Header />
            <main className="catalogo-eventos-page">
                <section className="container-eventos">
                    <div className="eventos-titulo">
                        <h1>Catálogo de Eventos</h1>
                        <hr />
                    </div>

                    {categorias.length > 1 ? (
                        <div className="eventos-filtro-categorias" role="tablist" aria-label="Filtro de categorias">
                            {categorias.map((categoria) => (
                                <button
                                    key={categoria}
                                    type="button"
                                    role="tab"
                                    aria-selected={categoriaAtiva === categoria}
                                    className={`eventos-filtro-item ${categoriaAtiva === categoria ? "ativo" : ""}`}
                                    onClick={() => setCategoriaAtiva(categoria)}
                                >
                                    {categoria}
                                </button>
                            ))}
                        </div>
                    ) : null}

                    {carregando ? <p className="eventos-status">Carregando eventos...</p> : null}
                    {!carregando && eventosFiltrados.length === 0 ? (
                        <p className="eventos-status">Nenhum evento encontrado para esta categoria.</p>
                    ) : null}

                    <div className="eventos">
                        {eventosFiltrados.map((evento) => (
                            <CardEvento
                                key={evento.idEvento}
                                id={evento.idEvento}
                                imagem={evento.imagemUrl}
                                categoria={evento.idTipoEventoNavigation?.titulo}
                                titulo={evento.nome}
                                descricao={evento.descricao}
                            />
                        ))}
                    </div>
                </section>
            </main>
            <Footer />
        </>
    );
}

export default Eventos;
