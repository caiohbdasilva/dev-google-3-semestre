import "./ListaTipos.css";

import lapis from "../../assets/icons/lapis.svg";
import lixeira from "../../assets/icons/lixeira.svg";

export interface ItemTipo {
    id: string;
    titulo: string;
}

interface ListaTiposProps {
    tituloSecao: string;
    itens: ItemTipo[];
    idEmEdicao: string | null;
    carregando?: boolean;
    mensagemVazia?: string;
    onEditar: (item: ItemTipo) => void;
    onExcluir: (item: ItemTipo) => void;
}

function ListaTipos({
    tituloSecao,
    itens,
    idEmEdicao,
    carregando,
    mensagemVazia = "Nenhum registro cadastrado",
    onEditar,
    onExcluir,
}: ListaTiposProps) {
    return (
        <section className="lista-tipos">
            <div className="lista-tipos-conteudo">
                <div className="lista-tipos-titulo">
                    <h2>{tituloSecao}</h2>
                    <hr />
                </div>

                <div className="lista-tipos-tabela-wrapper">
                    <table className="lista-tipos-tabela">
                        <thead>
                            <tr>
                                <th>Titulo</th>
                                <th className="lista-tipos-coluna-acao">Editar</th>
                                <th className="lista-tipos-coluna-acao">Deletar</th>
                            </tr>
                        </thead>
                        <tbody>
                            {carregando ? (
                                <tr>
                                    <td colSpan={3} className="lista-tipos-tabela-vazia">
                                        Carregando...
                                    </td>
                                </tr>
                            ) : null}

                            {!carregando && itens.length === 0 ? (
                                <tr>
                                    <td colSpan={3} className="lista-tipos-tabela-vazia">
                                        {mensagemVazia}
                                    </td>
                                </tr>
                            ) : null}

                            {!carregando &&
                                itens.map((item) => (
                                    <tr
                                        className={idEmEdicao === item.id ? "lista-tipos-linha-ativa" : ""}
                                        key={item.id}
                                    >
                                        <td>{item.titulo}</td>
                                        <td className="lista-tipos-coluna-acao">
                                            <button
                                                className="lista-tipos-acao"
                                                type="button"
                                                aria-label={`Editar ${item.titulo}`}
                                                onClick={() => onEditar(item)}
                                            >
                                                <img src={lapis} alt="Ícone de editar" />
                                            </button>
                                        </td>
                                        <td className="lista-tipos-coluna-acao">
                                            <button
                                                className="lista-tipos-acao"
                                                type="button"
                                                aria-label={`Deletar ${item.titulo}`}
                                                onClick={() => onExcluir(item)}
                                            >
                                                <img src={lixeira} alt="Ícone de deletar" />
                                            </button>
                                        </td>
                                    </tr>
                                ))}
                        </tbody>
                    </table>
                </div>
            </div>
        </section>
    );
}

export default ListaTipos;
