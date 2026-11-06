import bannerEvento1 from "../../assets/banner-1.png";
import bannerEvento2 from "../../assets/banner-2.png";
import bannerEvento3 from "../../assets/banner-3.png";

import "./Carrossel.css";

function Carrossel() {
    return (
        <section
            id="carrosselEventPlus"
            className="carousel slide carrossel-eventplus"
            data-bs-ride="carousel"
            data-bs-interval="8000"
        >
            <div className="carousel-indicators carrossel-indicadores">
                <button
                    type="button"
                    data-bs-target="#carrosselEventPlus"
                    data-bs-slide-to="0"
                    className="active"
                    aria-current="true"
                    aria-label="Slide 1"
                />
                <button
                    type="button"
                    data-bs-target="#carrosselEventPlus"
                    data-bs-slide-to="1"
                    aria-label="Slide 2"
                />
                <button
                    type="button"
                    data-bs-target="#carrosselEventPlus"
                    data-bs-slide-to="2"
                    aria-label="Slide 3"
                />
            </div>

            <div className="carousel-inner">
                <div className="carousel-item active">
                    <img src={bannerEvento1} className="carousel-banner" alt="Banner do Primeiro Evento" />
                </div>
                <div className="carousel-item">
                    <img src={bannerEvento2} className="carousel-banner" alt="Banner do Segundo Evento" />
                </div>
                <div className="carousel-item">
                    <img src={bannerEvento3} className="carousel-banner" alt="Banner do Terceiro Evento" />
                </div>
            </div>

            <button
                className="carousel-control-prev carrossel-controle carrossel-controle-prev"
                type="button"
                data-bs-target="#carrosselEventPlus"
                data-bs-slide="prev"
                aria-label="Banner anterior"
            >
                <span className="carrossel-seta-circulo" aria-hidden="true">
                    &#8592;
                </span>
            </button>
            <button
                className="carousel-control-next carrossel-controle carrossel-controle-next"
                type="button"
                data-bs-target="#carrosselEventPlus"
                data-bs-slide="next"
                aria-label="Próximo banner"
            >
                <span className="carrossel-seta-circulo" aria-hidden="true">
                    &#8594;
                </span>
            </button>
        </section>
    );
}

export default Carrossel;
