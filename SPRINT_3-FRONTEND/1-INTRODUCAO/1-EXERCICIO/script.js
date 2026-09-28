//## 1. Apresentação pessoal: Crie um programa que armazene seu nome, idade, cidade e profissão e exiba uma frase de apresentação completa no console.

const apresentacaoPessoal = {
    nome: "Caio",
    idade: 25,
    cidade: "São Bernardo do Campo",
    Profissao: "Desenvolvedor Full-Stack"
}

console.log(`Olá! Meu nome é ${apresentacaoPessoal.nome}, tenho ${apresentacaoPessoal.idade} anos e moro na cidade de ${apresentacaoPessoal.cidade}.`)

//## 2. Operações matemática: Crie um programa com dois números e exiba o resultado da soma, subtração, multiplicação e divisão entre eles.

function operacoesMatematicas(a,b){
    return `Adição: ${a+b};\nSubtração: ${a-b};\nMultiplicação: ${a*b};\nDivisão: ${a/b}`
}

console.log(operacoesMatematicas(10,5))

//## 3. Conversor de idade: Crie um programa que receba uma idade em anos e mostre aproximadamente quantos meses essa pessoa já viveu.

function conversorDeIdadeParaMeses(idade){
    return `O usuário viveu, aproximadamente, ${idade*12} meses`
}

console.log(conversorDeIdadeParaMeses(26))

//## 4. Média de notas: Crie um programa que armazene três notas de um aluno, calcule a média e exiba o resultado.
const aluno = {
    nome: "Caio",
    nota1: 10,
    nota2: 6,
    nota3: 4
}

function calcularMedia(a,b,c){
    return (a+b+c)/3
}

console.log(`
BOLETIM DO ALUNO
------------------------------
NOME: ${aluno.nome}
NOTA 1: ${aluno.nota1.toFixed(2)}
NOTA 2: ${aluno.nota2.toFixed(2)}
NOTA 3: ${aluno.nota3.toFixed(2)}
MÉDIA: ${calcularMedia(aluno.nota1, aluno.nota2, aluno.nota3).toFixed(2)}`)


//## 5. Maioridade: Crie um programa que informe se uma pessoa é maior ou menor de idade a partir da idade informada.
function verificacaoMaioridade(idade){
    if (idade >= 18){
        return "O usuário é maior de idade"
    } else { 
        return "O usuário é menor de idade"
    }
}
console.log(verificacaoMaioridade(apresentacaoPessoal.idade))

//## 6. Número positivo, negativo ou zero: Crie um programa que analise um número e informe se ele é positivo, negativo ou igual a zero.

function verificacaoNumero(numero){
    if (numero>0){
        return "O número é positivo."
    } else if (numero<0){
        return "O número é negativo."
    } else {
        return "O número é zero."
    }
}

console.log(verificacaoNumero(10))

//## 7. Par ou ímpar: Crie um programa que informe se um número é par ou ímpar.

function verificacaoPar(numero){
    if (numero%2 == 0){
        return "O número é par."
    } else { 
        return "O número é ímpar."
    }
}

console.log(verificacaoPar(2))

//## 8. Situação do aluno: Crie um programa que calcule a média de duas notas e informe se o aluno está aprovado, em recuperação ou reprovado. Considere:
// - aprovado: média maior ou igual a 7;
// - recuperação: média entre 5 e 6,9;
// - reprovado: média menor que 5.

const aluno2 = {
    nome: "José da Silva",
    nota1: 10,
    nota2: 7
}

function situacaoAluno(a,b){
    const media = (a+b)/2;
    let situacao = "";
    if(media>=7){
        situacao = "Aprovado"
    } else if (media>=5){
        situacao = "Recuperação"
    } else {
        situacao = "Reprovado"
    }
    return {media, situacao}
}

console.log(`
BOLETIM DO ALUNO
------------------------------
NOME: ${aluno2.nome}
NOTA 1: ${aluno2.nota1.toFixed(2)}
NOTA 2: ${aluno2.nota2.toFixed(2)}
MÉDIA: ${situacaoAluno(aluno2.nota1, aluno2.nota2).media.toFixed(2)}
SITUAÇÃO: ${situacaoAluno(aluno2.nota1, aluno2.nota2).situacao}`)

//## 9. Maior entre dois números: Crie um programa que compare dois números e informe qual deles é o maior. Caso sejam iguais, informe isso ao usuário.

function maiorNumero(a,b){
    if (a>b){
        return `${a} é maior do que ${b}`
    } else if (b>a){
        return `${b} é maior do que ${a}`
    } else {
        return "Os números são iguais."
    }
}

console.log(maiorNumero(10,10))

//## 10. Maior entre três números: Crie um programa que compare três números e informe qual deles é o maior.

function maiorEntreTres(a, b, c) {
    let maior = a;
    if (b > maior) {
        maior = b;
    }
    if (c > maior) {
        maior = c;
    }
    return `O maior número entre ${a}, ${b} e ${c} é ${maior}.`;
}

console.log(maiorEntreTres(15, 42, 8));

//## 11. Cálculo de desconto: Crie um programa que armazene o preço de um produto. Caso o preço seja maior que R$ 100, aplique um desconto de 10%. Ao final, exiba o valor original e o valor final.

function calcularDesconto(preco) {
    let valorFinal = preco;
    if (preco > 100) {
        valorFinal = preco - (preco * 0.10);
    }
    return `Valor original: R$ ${preco.toFixed(2)}\nValor final: R$ ${valorFinal.toFixed(2)}`;
}

console.log(calcularDesconto(150.00));

//## 12. Controle de acesso: Crie um programa que verifique se uma pessoa pode acessar determinada área. O acesso só deve ser permitido para pessoas maiores de idade que estejam autorizadas.

function controleDeAcesso(idade, possuiAutorizacao) {
    if (idade >= 18 && possuiAutorizacao) {
        return "Acesso permitido.";
    } else {
        return "Acesso negado.";
    }
}

console.log(controleDeAcesso(20, true));
console.log(controleDeAcesso(17, true));

//## 13. Lista de nomes: Crie uma lista contendo pelo menos cinco nomes e exiba todos os nomes no console.

const listaDeNomes = ["Caio", "Angela", "Ednaldo", "Gabriel", "Mariana"];

console.log("Lista de Nomes:");
listaDeNomes.forEach(nome => console.log(nome));

//## 14. Lista de compras: Crie uma lista de compras com pelo menos cinco produtos. Exiba a quantidade total de itens e todos os produtos cadastrados.

const listaDeCompras = ["Arroz", "Feijão", "Café", "Açúcar", "Leite"];

console.log(`Quantidade total de itens: ${listaDeCompras.length}`);
console.log(`Produtos: ${listaDeCompras.join(", ")}`);

//## 15. Cadastro de pessoa: Crie uma estrutura que represente uma pessoa contendo nome, idade, cidade e profissão. Exiba todas as informações dessa pessoa no console.

const pessoa = {
    nome: "Lucas",
    idade: 28,
    cidade: "São Caetano do Sul",
    profissao: "Engenheiro de Software"
};

console.log(`Nome: ${pessoa.nome}\nIdade: ${pessoa.idade}\nCidade: ${pessoa.cidade}\nProfissão: ${pessoa.profissao}`);

//## 16. Cadastro de produto: Crie uma estrutura que represente um produto contendo nome, preço, categoria e disponibilidade. Exiba uma frase apresentando todas as informações do produto.

const produto = {
    nome: "Monitor Ultrawide",
    preco: 1200.50,
    categoria: "Periféricos",
    disponibilidade: true
};

console.log(`O produto ${produto.nome}, da categoria ${produto.categoria}, custa R$ ${produto.preco.toFixed(2)} e atualmente ${produto.disponibilidade ? "está disponível" : "está indisponível"} no estoque.`);

//## 17. Cadastro de alunos: Crie uma lista com pelo menos três alunos. Cada aluno deve possuir nome e idade. Exiba os dados de todos os alunos no console.

const listaDeAlunos = [
    { nome: "Ana", idade: 16 },
    { nome: "Bruno", idade: 15 },
    { nome: "Carlos", idade: 17 }
];

console.log("Dados dos Alunos:");
listaDeAlunos.forEach(aluno => {
    console.log(`Aluno(a): ${aluno.nome}, Idade: ${aluno.idade} anos`);
});

//## 18. Dobro de um número: Crie um programa que receba um número e devolva o dobro desse valor. Teste com diferentes números.

function calcularDobro(numero) {
    return numero * 2;
}

console.log(`O dobro de 5 é ${calcularDobro(5)}`);
console.log(`O dobro de 12.5 é ${calcularDobro(12.5)}`);
console.log(`O dobro de -4 é ${calcularDobro(-4)}`);

//## 19. Calculadora de soma: Crie um programa que receba dois números e devolva a soma entre eles. Faça pelo menos três testes diferentes.

function somarNumeros(a, b) {
    return a + b;
}

console.log(`Soma 1 (10 + 15): ${somarNumeros(10, 15)}`);
console.log(`Soma 2 (-5 + 8): ${somarNumeros(-5, 8)}`);
console.log(`Soma 3 (2.5 + 3.1): ${somarNumeros(2.5, 3.1)}`);

//## 20. Calculadora de média: Crie um programa que receba duas notas e devolva a média entre elas. Faça testes com valores diferentes.

function mediaDuasNotas(nota1, nota2) {
    return (nota1 + nota2) / 2;
}

console.log(`Média (8 e 10): ${mediaDuasNotas(8, 10).toFixed(2)}`);
console.log(`Média (4.5 e 6.5): ${mediaDuasNotas(4.5, 6.5).toFixed(2)}`);

//## 21. Saudação personalizada: Crie um programa que receba o nome de uma pessoa e exiba uma mensagem de boas-vindas personalizada.

function saudacaoPersonalizada(nome) {
    return `Olá, ${nome}! Seja muito bem-vindo(a) ao nosso sistema.`;
}

console.log(saudacaoPersonalizada("Caio"));

//## 22. Tabuada: Crie um programa que exiba a tabuada completa de um número de 1 até 10.

function exibirTabuada(numero) {
    console.log(`\nTABUADA DO ${numero}`);
    for (let i = 1; i <= 10; i++) {
        console.log(`${numero} x ${i} = ${numero * i}`);
    }
}

exibirTabuada(7);

//## 23. Contagem crescente: Crie um programa que exiba os números de 1 até 20.

function contagemCrescente() {
    let numeros = [];
    for (let i = 1; i <= 20; i++) {
        numeros.push(i);
    }
    console.log(`Contagem crescente: ${numeros.join(", ")}`);
}

contagemCrescente();

//## 24. Contagem regressiva: Crie um programa que exiba uma contagem regressiva de 10 até 0 e, ao final, mostre a mensagem "Fim!".

function contagemRegressiva() {
    console.log("\nIniciando contagem regressiva:");
    for (let i = 10; i >= 0; i--) {
        console.log(i);
    }
    console.log("Fim!");
}

contagemRegressiva();

//## 25. Números pares: Crie um programa que exiba todos os números pares entre 1 e 50.

function exibirPares() {
    let pares = [];
    for (let i = 1; i <= 50; i++) {
        if (i % 2 === 0) {
            pares.push(i);
        }
    }
    console.log(`\nNúmeros pares de 1 a 50:\n${pares.join(", ")}`);
}

exibirPares();

//## 26. Soma de uma lista: Crie uma lista contendo cinco números e calcule a soma de todos eles.

const cincoNumeros = [12, 45, 7, 23, 10];

function somarLista(lista) {
    let soma = 0;
    for (let numero of lista) {
        soma += numero;
    }
    return soma;
}

console.log(`\nA soma dos números da lista [${cincoNumeros.join(", ")}] é: ${somarLista(cincoNumeros)}`);

//## 27. Média de uma lista: Crie uma lista contendo cinco notas e calcule a média de todas elas.

const cincoNotas = [7.5, 8.0, 6.5, 9.0, 10.0];

function calcularMediaLista(lista) {
    let soma = 0;
    for (let nota of lista) {
        soma += nota;
    }
    return soma / lista.length;
}

console.log(`A média das notas [${cincoNotas.join(", ")}] é: ${calcularMediaLista(cincoNotas).toFixed(2)}`);

//## 28. Verificação de disponibilidade: Crie um programa que represente um produto com nome, preço e quantidade em estoque. Informe se o produto está disponível ou indisponível.

const itemEstoque = {
    nome: "Teclado Mecânico",
    preco: 350.00,
    quantidade: 0
};

function verificarDisponibilidade(produto) {
    if (produto.quantidade > 0) {
        return `O produto '${produto.nome}' está DISPONÍVEL (Estoque: ${produto.quantidade}).`;
    } else {
        return `O produto '${produto.nome}' está INDISPONÍVEL no momento.`;
    }
}

console.log(verificarDisponibilidade(itemEstoque));

//## 29. Boletim completo: Crie um programa que armazene o nome de um aluno e duas notas. Calcule a média e exiba o nome, a média e a situação final do aluno.

const alunoBoletim = {
    nome: "Julia",
    nota1: 5.5,
    nota2: 6.0
};

function gerarBoletimSimples(aluno) {
    let media = (aluno.nota1 + aluno.nota2) / 2;
    let situacao = "";
    if (media >= 7) {
        situacao = "Aprovado";
    } else if (media >= 5) {
        situacao = "Recuperação";
    } else {
        situacao = "Reprovado";
    }
    
    return `Boletim de ${aluno.nome} - Média: ${media.toFixed(2)} | Situação: ${situacao}`;
}

console.log(gerarBoletimSimples(alunoBoletim));

//## 30. Desafio final — Sistema de alunos: Crie um programa com pelo menos três alunos. Cada aluno deve possuir nome, nota 1 e nota 2. Para cada aluno, o programa deve calcular a média e exibir: nome; primeira nota; segunda nota; média final; situação: aprovado, recuperação ou reprovado.

const sistemaDeAlunos = [
    { nome: "Pedro", nota1: 4.0, nota2: 5.0 },
    { nome: "Mariana", nota1: 9.5, nota2: 8.5 },
    { nome: "Thiago", nota1: 6.0, nota2: 7.0 }
];

function relatorioSistemaDeAlunos(alunos) {
    console.log("\nRELATÓRIO FINAL - SISTEMA DE ALUNOS");
    alunos.forEach(aluno => {
        let media = (aluno.nota1 + aluno.nota2) / 2;
        let situacao = "";
        
        if (media >= 7) {
            situacao = "Aprovado";
        } else if (media >= 5) {
            situacao = "Recuperação";
        } else {
            situacao = "Reprovado";
        }

        console.log("------------------------------");
        console.log(`NOME: ${aluno.nome}`);
        console.log(`PRIMEIRA NOTA: ${aluno.nota1.toFixed(2)}`);
        console.log(`SEGUNDA NOTA: ${aluno.nota2.toFixed(2)}`);
        console.log(`MÉDIA FINAL: ${media.toFixed(2)}`);
        console.log(`SITUAÇÃO: ${situacao}`);
    });
    console.log("------------------------------");
}

relatorioSistemaDeAlunos(sistemaDeAlunos);
