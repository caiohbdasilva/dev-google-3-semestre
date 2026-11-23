import type { RespostaLogin } from "../types/auth";

//Função de salvar a sessão do usuário
export function salvarSessao(dados: RespostaLogin) {
    //sessionStorage: armazena informações durante a sessão da aba do navegador
    //setItem(): salva uma informação (ex: token: akskhakndkhakjdskf)
    sessionStorage.setItem("token", dados.token);
    //Cria a chave(variável) usuário e cria um json para tranformar o objeto usuario recebido pela API em um texto jsom
    //Fica mais ou menos assim na sessão:
    // usuario:{
    //     nome: Usuario,
    //     email: usuario@teste.com,
    //     tipoUsuario: "Admin"
    // }
    sessionStorage.setItem("usuario", JSON.stringify({
        idUsuario: dados.usuario.idUsuario,
        nome: dados.usuario.nome,
        email: dados.usuario.email,
        tipoUsuario: dados.usuario.tipoUsuario,
        fotoPerfil: dados.usuario.fotoPerfil
    }));
    sessionStorage.setItem("expiracaoUtc", dados.expiracaoUtc);
}

export function obterToken() {
    //getItem(): Recupera uma informação
    //Aqui nesta função retornamos o token
    return sessionStorage.getItem("token");
}

export function obterUsuario(){
    const usuario = sessionStorage.getItem("usuario");
    //JSON.parse(): transforma o texto JSON novamente em objeto
    //Valida se o usuário existe
    //Se existir (?): retorna o objeto com as informações do usuário
    //Se não (:): retorna null
    return usuario ? JSON.parse(usuario) : null;
}

//Limpando a sessão do navegador
export function encerrarSessao(){
    sessionStorage.removeItem("token");
    sessionStorage.removeItem("usuario");
    sessionStorage.removeItem("expiracaoUtc");
}

export function sessaoValida(){

    const token = obterToken();
    const expiracaoUtc = sessionStorage.getItem("expiracaoUtc");

    //se não existir um token (!token) ou data de expiracao (!expiracao) retorna false
    if (!token || !expiracaoUtc) {
        return false;
    }

    //Verifica se a data de expiracao é maior que a data atual
    //retorna true se o token ainda estiver dentro do prazo de validade e false se estiver expirado
    return new Date(expiracaoUtc).getTime() > Date.now();
}