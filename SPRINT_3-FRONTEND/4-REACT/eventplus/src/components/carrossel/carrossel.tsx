import "./carrossel.css"
import bannerEvento1 from "../../assets/banner-1.png"
import bannerEvento2 from "../../assets/banner-2.png"
import bannerEvento3 from "../../assets/banner-3.png"

function Carrossel() {
    return(
        <section id="CarrosselEventPlus" 
        className="carousel slide"
        data-bs-ride="carousel"
        data-bs-interval="1000">
            <div className="carousel-inner">
                <div className="carousel-item active">
                    <img src={bannerEvento1} alt="Banner do primeiro evento" className="carousel-banner" />
                </div>
                <div className="carousel-item">
                    <img src={bannerEvento2} alt="Banner do segundo evento" className="carousel-banner" />
                </div>
                <div className="carousel-item">
                    <img src={bannerEvento3} alt="Banner do terceiro evento" className="carousel-banner" />
                </div>
            </div>
            <button className="carousel-control-prev"
            type="button"
            data-bs-target="#CarrosselEventPlus"
            data-bs-slide="prev">
                <span className="carousel-control-prev-icon" aria-hidden="true">
                    
                </span>
            </button>
            <button className="carousel-control-next"
            type="button"
            data-bs-target="#CarrosselEventPlus"
            data-bs-slide="next">
                <span className="carousel-control-next-icon" aria-hidden="true">

                </span>
            </button>
        </section>
    )
}

export default Carrossel;