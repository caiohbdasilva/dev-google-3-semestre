// A resposta que recebemos da api;
// Esta interface define o formato esperado da resposta;
// Os nomes precisam ser iguais ao do JSON retornado da API (Swagger);

export interface UsuarioSessao {
    idUsuario: number;
    nome: string;
    email: string;
    tipoUsuario: string;
    ativo: boolean;
    fotoPerfil: string | null;
}

export interface RespostaLogin {
    token: string;
    expiracaoUtc: string;
    usuario: UsuarioSessao;
}