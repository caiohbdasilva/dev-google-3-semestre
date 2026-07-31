using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISTEMA_BANCARIO.Models
{
    public abstract class Conta
    {
        public string Titular{get;}
        public decimal Saldo{get; protected set;} 
                // Propriedades: Titular e Saldo
        // visibilidade, tipo de dado, nome da propriedade, acessores

        //Encapsulamento == Proteger
        //O saldo é o dado mais sensível, ninguém de fora grava direto
        // Protected set: Só a própria classe e suas filhas podem alterar
        // A leitura só será permitida se passar pelos métodos SACAR e DEPOSITAR (que serão criados ainda)
        protected Conta(string titular, decimal saldo)
        //Método Construtor
        {
            Titular = titular;
            Saldo = saldo;
        }

        //Métodos SACAR e DEPOSITAR
        //Visibilidade, retorno, nome, parametros
        public void Depositar(decimal valor)
        {
            if (valor<= 0)
            {
                throw new ArgumentException("Depósito precisa ser positivo!");
            } else
            {
                Saldo = Saldo + valor;
            }
        }

        public abstract void Sacar(decimal valor);
        //Polimorfismo
        //Toda a conta saca, mas com suas peculiaridades. A base(aqui), só exige o método, a implementação será nas "filhas"
    
        
    }
}