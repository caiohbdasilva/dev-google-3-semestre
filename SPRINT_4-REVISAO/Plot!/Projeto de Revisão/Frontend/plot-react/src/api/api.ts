import axios from "axios";
import { obterToken } from "../services/sessaoService";

export const api = axios.create({
    baseURL: "https://localhost:7235/api/" //Define o endereço principal da nossa API
})

// interceptors -> intercepta as requisições antes de enviá-las para API para configurar a autenticação
// config -> é um objeto do axios que contem as configurações da requisição
// requisição: url, métodos http, cabeçalho da requisição(onde fica o token por exemplo) e dados que retornam 
api.interceptors.request.use((config) => {
    //aqui pegamos o token recebido na sessão
    const token = obterToken();

    //Se existir um token, adiciona ao cabeçalho da requisição (headers)
    if (token) {
        config.headers.Authorization = `Bearer ${token}`
    }

    //retorna as configurações atualizadas da requisição
    return config;
})