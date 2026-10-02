function adicionarTarefa(){
    const input = document.querySelector("#novaTarefa")
    const mensagem = document.querySelector("#mensagem")
    const listaTarefas = document.querySelector("#listaTarefas")

    if (input.value === "") {
        mensagem.textContent = "Digite uma tarefa."
        return;
    } else { 
        mensagem.textContent = "";
    }

    const tarefa = document.createElement("li");
    //crio o botao para a tarefa
    const remover = document.createElement("button");

    //Adiciono o texto no botao
    remover.textContent = "Remover";

    //Adiciona a função de remover a tarefa dentro do botao
    remover.onclick = function(){
        tarefa.remove();
    }

    tarefa.textContent = input.value;

    //Adiciona o botao de remover dentro da tarefa
    tarefa.appendChild(remover);

    listaTarefas.appendChild(tarefa);
    
    input.value = ""
    mensagem.value = ""



}

