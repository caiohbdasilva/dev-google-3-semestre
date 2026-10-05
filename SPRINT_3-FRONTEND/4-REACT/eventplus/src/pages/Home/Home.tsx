import logoEvent from "../../assets/logo-event.svg"
import bannerevento1 from "../../assets/banner-1.png"
import bannerevento2 from "../../assets/banner-2.png"
import bannerevento3 from "../../assets/banner-3.png"
import visaoimg from "../../assets/visao-img.png"

import Carrossel from "../../components/carrossel/carrossel"

import "./Home.css"

function Home(){
    return (
        <>
        <header className="home-header">
            <div className="home-header-conteudo">
                <img src={logoEvent} alt="Logo Event+" />
                
                <nav>
                    <a href="#inicio">Home</a>
                    <a href="#eventos">Eventos</a>
                    <a href="#usuarios">Usuários</a>
                    <a href="#contatos">Contatos</a>
                </nav>

                <button>Entrar</button>
            </div>
        </header>
        <main>
            <Carrossel />

            <section className="teste"></section>

            <section className="home-visao">
                <div className="home-visao-container">
                <img src={visaoimg} alt="Pessoas confratenizando" />
                <div className="home-visao-texto">
                <h1>VISÃO</h1>
                <p>A EventPlus organiza eventos e informações em uma interface direta, facilitando a consulta da agenda e a participação dos usuários.</p>                    
                </div>
                </div>
            </section>

            <section id="eventos" className="home-eventos">
                <div className="home-eventos-titulo">
                    <h2>Próximos eventos</h2>
                    <hr />
                </div>
                <div className="home-eventos-lista">
                    <article className="home-eventos-card">
                        <img src={bannerevento1} alt="Evento de tecnologia" />
                        <span>Tecnologia</span>
                        <div className="home-eventos-card-info">
                            <h3>Evento de Tecnologia</h3>
                            <p>Conheça novidades e tendências dp setor</p>
                            <button type="button">Ver Evento</button>
                        </div>
                    </article>
                    <article className="home-eventos-card">
                        <img src={bannerevento2} alt="Workshop de Desenvolvimento" />
                        <span>Workshop</span>
                        <div className="home-eventos-card-info">
                            <h3>Workshop de Desenvolvimento</h3>
                            <p>Pratique desenvolvimento com atividades guiadas</p>
                            <button type="button">Ver Evento</button>
                        </div>
                    </article>
                    <article className="home-eventos-card">
                        <img src={bannerevento3} alt="Meetup de inteligência" />
                        <span>Meetup</span>
                        <div className="home-eventos-card-info">
                            <h3>Meetup de IA</h3>
                            <p>Discussões sobre aplicações de inteligência artificial</p>
                            <button type="button">Ver Evento</button>
                        </div>
                    </article>
                </div>
            </section>
            <section id="contatos" className="home-contato">
                <div className="home-contato-container">
                    <div className="home-contato-titulo">
                        <h2>Contato</h2>
                        <hr />
                    </div>
                    <div className="home-contato-conteudo">
                        <div className="home-contato-texto">
                            <p>Rua Niterói, 180 - Centro</p>
                            <p>São Caetano do Sul - SP</p>
                        </div>
                            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d29245.59436091304!2d-46.60881042480468!3d-23.61511502711369!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94ce5d11c031c57f%3A0x8f79f71018065a16!2sSENAI%20S%C3%A3o%20Caetano%20do%20Sul%20-%20Cyber%20e%20IA!5e0!3m2!1spt-BR!2sbr!4v1791222347916!5m2!1spt-BR!2sbr"  loading="lazy"></iframe>
                    </div>
                </div>
            </section>
        </main>
        <footer className="home-footer">
            <p>Escola de Senai de Informática - 2026</p>
        </footer>
        </>
    );
}

export default Home;