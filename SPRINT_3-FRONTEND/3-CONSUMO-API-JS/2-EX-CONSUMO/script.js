async function carregarTime() {
    const mensagem = document.querySelector("#mensagem")
    mensagem.textContent = "Iniciando a busca..."

    const resposta = await fetch("https://www.thesportsdb.com/api/v1/json/123/searchteams.php?t=Corinthians")

    console.log(resposta)

    const time = await resposta.json();

    console.log(time)

    const infoTime = time;

    const lista = document.querySelector("#listaInfos")
    lista.textContent = "";

    for (let cont = 0; cont < infoTime.length; cont++) {
        console.log("teste", infoTime[cont])
        const timao = infoTime[cont]

        const cartao = document.createElement("article")
        const titulo = document.createElement("h2")
        const img = document.createElement("img")

        titulo.textContent = timao.strTeam;
        img.src = timao.strLogo

        const NomeTime = document.createElement("p")
        nomeTime.textContent = `Nome: ${timao.strTeam}`

        const imgTime = document.createElement("img")
        imgTime.src = timao.strLogo

        // const imgNinja2 = document.createElement("img")
        // imgNinja2.src = ninja.images[1]

        // const usuarioTexto = document.createElement("p")
        // usuarioTexto.textContent = `Usuário: ${usuario.username}`

        // const usuarioEmail = document.createElement("p")
        // usuarioEmail.textContent = `Email: ${usuario.email}`

        // const usuarioCidade = document.createElement("p")
        // usuarioCidade.textContent = `Cidade: ${usuario.address.city}`

        // const usuarioEmpresa = document.createElement("p")
        // usuarioEmpresa.textContent = `Empresa: ${usuario.company.name}`

        cartao.appendChild(NomeTime);
        cartao.appendChild(imgTime);
        // cartao.appendChild(imgNinja2);
        // cartao.appendChild(usuarioEmail);
        // cartao.appendChild(usuarioCidade);
        // cartao.appendChild(usuarioEmpresa);

        lista.appendChild(cartao);
    }



    mensagem.textContent = "Time buscado:"
}

carregarTime();