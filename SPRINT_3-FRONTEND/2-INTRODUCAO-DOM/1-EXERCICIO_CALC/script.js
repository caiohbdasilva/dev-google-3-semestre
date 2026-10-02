const operacoes = ["+", "-", "x", "÷", "Limpar"];
const operacoesBotao = document.querySelector("#botoes-container");


let operacaoEscolhida = ""; 

for (let cont = 0; cont < operacoes.length; cont++) {
    const operacao = document.createElement("button");
    operacao.textContent = operacoes[cont];

  
    operacao.onclick = function() {
        operacaoEscolhida = operacoes[cont];
        
       
        calcularResultado(); 
    };

    operacoesBotao.appendChild(operacao);
}


function calcularResultado() {
    const input1 = document.querySelector("#primeiroNumero");
    const input2 = document.querySelector("#segundoNumero");
    const visorResultado = document.querySelector("#resultado");

    const num1 = Number(input1.value);
    const num2 = Number(input2.value);


    if (operacaoEscolhida === "+") {
        visorResultado.textContent = num1 + num2;
    } else if (operacaoEscolhida === "-") {
        visorResultado.textContent = num1 - num2;
    } else if (operacaoEscolhida === "x") {
        visorResultado.textContent = num1 * num2;
    } else if (operacaoEscolhida === "÷") {
        visorResultado.textContent = num1 / num2;
    } else if (operacaoEscolhida === "Limpar") {
        input1.value = "";
        input2.value = "";
        visorResultado.textContent = "";
        operacaoEscolhida = ""; 
    }
}