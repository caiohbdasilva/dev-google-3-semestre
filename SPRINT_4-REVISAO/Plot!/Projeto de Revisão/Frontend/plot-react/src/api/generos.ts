import type { Genero } from "../types/genero";
import { api } from "./api";

export async function listarGeneros() : Promise<Genero[]> {
    
    //Realiza uma requisição Get na API e aguarda a resposta com uma lista de gênero
    const resposta = await api.get<Genero[]>("Genero");

    return resposta.data;
}