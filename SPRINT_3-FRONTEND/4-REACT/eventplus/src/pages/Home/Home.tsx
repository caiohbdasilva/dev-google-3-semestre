import { useCallback, useEffect, useState } from "react";
import { useLocation } from "react-router-dom";

import visaoImg from "../../assets/visao-img.png";
import CardEvento from "../../components/cardEvento/CardEvento";
import Carrossel from "../../components/carrossel/Carrossel";
import Footer from "../../components/footer/Footer";
import Header from "../../components/header/Header";
import { getApiErrorMessage } from "../../services/api";
import { eventoService } from "../../services/eventPlusservice";
import type { Evento } from "../../types/api";
import "./Home.css";

function Home() {
    const location = useLocation();
    const [eventos, setEventos] = useState<Evento[]>([]);
    const [carregando, setCarregando] = useState(true);
    const [erro, setErro] = useState("");

    const carregar = useCallback(async () => {
        setCarregando(true);
        setErro("");
        try {
            setEventos((await eventoService.listarProximos()).slice(0, 3));
        } catch (error) {
            setErro(getApiErrorMessage(error));
        } finally {
            setCarregando(false);
        }
    }, []);

    useEffect(() => {
        const timeout = window.setTimeout(() => void carregar(), 0);
        return () => window.clearTimeout(timeout);
    }, [carregar]);

    useEffect(() => {
        if (location.hash === "#contato") {
            requestAnimationFrame(() => {
                document.querySelector("#contato")?.scrollIntoView({ behavior: "smooth" });
            });
        }
    }, [location.hash]);

    return (
        <>
            <Header />
            <main>
                <Carrossel />

                <section className="home-visao">
                    <div className="home-visao-container">
                        <img src={visaoImg} alt="Pessoas conversando" />
                        <div className="home-visao-texto">
                            <h1>VISÃO</h1>
                            <p>
                                A EventPlus organiza eventos e informações em uma interface direta, com foco em facilitar a consulta da agenda, o cadastro e a navegação entre as telas principais.
                            </p>
                        </div>
                    </div>
                </section>

                <section id="eventos" className="home-eventos">
                    <div className="home-eventos-titulo">
                        <h2>PRÓXIMOS EVENTOS</h2>
                        <hr />
                    </div>
                    {carregando ? <p className="home-eventos-status">Carregando próximos eventos...</p> : null}
                    {erro ? <p className="home-eventos-status">{erro}</p> : null}
                    {!carregando && !erro && eventos.length === 0 ? (
                        <p className="home-eventos-status">Nenhum próximo evento cadastrado.</p>
                    ) : null}
                    <div className="home-eventos-lista">
                        {eventos.map((evento) => (
                            <CardEvento
                                key={evento.idEvento}
                                id={evento.idEvento}
                                titulo={evento.nome}
                                imagem={evento.imagemUrl}
                                descricao={evento.descricao}
                                categoria={evento.idTipoEventoNavigation?.titulo}
                            />
                        ))}
                    </div>
                </section>

                <section id="contato" className="home-contato">
                    <div className="home-contato-container">
                        <div className="home-contato-titulo">
                            <h2>CONTATO</h2>
                            <hr />
                        </div>
                        <div className="home-contato-conteudo">
                            <div className="home-contato-texto">
                                <p className="home-contato-rua">Rua Niterói, 180 - Centro</p>
                                <p>São Caetano do Sul - SP</p>
                                <p>(11) 4225-2000</p>
                            </div>
                            <iframe
                                title="Localização SENAI São Caetano do Sul"
                                src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d29245.591198054055!2d-46.60883312568361!3d-23.61512919999998!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94ce5d11c031c57f%3A0x8f79f71018065a16!2sSENAI%20S%C3%A3o%20Caetano%20do%20Sul%20-%20Cyber%20e%20IA!5e0!3m2!1spt-BR!2sbr!4v1791222270858!5m2!1spt-BR!2sbr"
                                loading="lazy"
                            />
                        </div>
                    </div>
                </section>
            </main>

            <Footer />
        </>
    );
}

export default Home;
