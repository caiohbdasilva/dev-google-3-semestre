import { Link } from "react-router-dom";

import imagemPadrao from "../../assets/banner-3.png";
import "./CardEvento.css";

interface CardEventoProps {
    id: string;
    imagem?: string | null;
    categoria?: string;
    titulo: string;
    descricao: string;
}

function CardEvento({ id, imagem, categoria, titulo, descricao }: CardEventoProps) {
    return (
        <article className="home-evento-card">
            <img src={imagem || imagemPadrao} alt={`Imagem do evento ${titulo}`} />
            <span className="home-evento-card-categoria">{categoria || "Categoria"}</span>
            <div className="home-evento-card-info">
                <h3>{titulo}</h3>
                <p>{descricao}</p>
                <Link to={`/eventos/${id}`}>Ver Evento</Link>
            </div>
        </article>
    );
}

export default CardEvento;
