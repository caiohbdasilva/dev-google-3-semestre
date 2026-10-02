async function carregarUsuarios() {
    const mensagem = document.querySelector("#mensagem")

    mensagem.textContent = "Iniciando a busca..."

    const resposta = await fetch("https://jsonplaceholder.typicode.com/users")

    console.log(resposta)

    const usuarios = await resposta.json();

    console.log(usuarios)

    const lista = document.querySelector("#listaUsuarios")
    lista.textContent = "";

    for (let cont = 0; cont < usuarios.length; cont++) {

        const usuario = usuarios[cont]

        const cartao = document.createElement("article")
        const titulo = document.createElement("h2")

        titulo.textContent = usuario.name;

        const usuarioTexto = document.createElement("p")
        usuarioTexto.textContent = `Usuário: ${usuario.username}`

        const usuarioEmail = document.createElement("p")
        usuarioEmail.textContent = `Email: ${usuario.email}`

        const usuarioCidade = document.createElement("p")
        usuarioCidade.textContent = `Cidade: ${usuario.address.city}`

        const usuarioEmpresa = document.createElement("p")
        usuarioEmpresa.textContent = `Empresa: ${usuario.company.name}`

        cartao.appendChild(titulo);
        cartao.appendChild(usuarioTexto);
        cartao.appendChild(usuarioEmail);
        cartao.appendChild(usuarioCidade);
        cartao.appendChild(usuarioEmpresa);

        lista.appendChild(cartao);
    }



    mensagem.textContent = "Usuários buscados:"
}