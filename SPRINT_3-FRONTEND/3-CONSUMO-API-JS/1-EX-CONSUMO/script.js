async function carregarNinja() {
    const mensagem = document.querySelector("#mensagem")
    mensagem.textContent = "Iniciando a busca..."

    const resposta = await fetch("https://dattebayo-api.onrender.com/characters")

    console.log(resposta)

    const ninjas = await resposta.json();

    console.log(ninjas.characters)

    const listaNinjas = ninjas.characters;

    const lista = document.querySelector("#listaJutsus")
    lista.textContent = "";

    for (let cont = 0; cont < listaNinjas.length; cont++) {
        console.log("teste", listaNinjas[cont])
        const ninja = listaNinjas[cont]

        const cartao = document.createElement("article")
        const titulo = document.createElement("h2")
        const img = document.createElement("img")

        titulo.textContent = ninja.name;
        img.src = ninja.images[0]

        const ninjaNome = document.createElement("p")
        ninjaNome.textContent = `Ninja: ${ninja.name}`

        const imgNinja1 = document.createElement("img")
        imgNinja1.src = ninja.images[0]

        const imgNinja2 = document.createElement("img")
        imgNinja2.src = ninja.images[1]

        // const usuarioTexto = document.createElement("p")
        // usuarioTexto.textContent = `Usuário: ${usuario.username}`

        // const usuarioEmail = document.createElement("p")
        // usuarioEmail.textContent = `Email: ${usuario.email}`

        // const usuarioCidade = document.createElement("p")
        // usuarioCidade.textContent = `Cidade: ${usuario.address.city}`

        // const usuarioEmpresa = document.createElement("p")
        // usuarioEmpresa.textContent = `Empresa: ${usuario.company.name}`

        cartao.appendChild(ninjaNome);
        cartao.appendChild(imgNinja1);
        cartao.appendChild(imgNinja2);
        // cartao.appendChild(usuarioEmail);
        // cartao.appendChild(usuarioCidade);
        // cartao.appendChild(usuarioEmpresa);

        lista.appendChild(cartao);
    }



    mensagem.textContent = "Ninjas buscados:"
}

carregarNinja();