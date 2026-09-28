const titulo = document.getElementById("titulo");
console.log(titulo.textContent);
titulo.textContent = "JavaScript alterou esse título"

const descricao = document.getElementById("descricao");
console.log(descricao.textContent);
descricao.textContent = "O conteúdo foi alterado pelo DOM."

const titulo1 = document.querySelector("#titulo")
console.log(titulo1)

const mensagem = document.querySelector(".mensagem")
console.log(mensagem)

const botao = document.querySelector("button")

const mensagens = document.querySelectorAll(".mensagem")
console.log(mensagens)

for (let cont = 0; cont < mensagens.length; cont++){
    console.log(mensagens[cont].textContent)
}

// titulo.style.color = "blue"
// titulo.style.backgroundColor = "lightgray"
// titulo.style.padding = "20px"

// descricao.style.fontSize = "20px"

titulo.classList.add("destaque")
titulo.classList.remove("destaque")
titulo.classList.toggle("destaque")

console.log(titulo.classList.contains("destaque"))

function mostrarMensagem(){
    titulo.textContent = "Botao clicado!"
}

function alternarDestaque(){
    titulo.classList.toggle("destaque");
}

function mostrarNome(){
    const inputNome = document.querySelector("#nome")
    const resultado = document.querySelector("#resultado")

    if (inputNome.value === ""){
        resultado.textContent = "Digite seu nome."
    } else {
        resultado.textContent = `Olá, ${inputNome.value}!`
    }

}