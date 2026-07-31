using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISTEMA_BANCARIO.Models
{

    //HERANÇA
    // ContaCorrente é uma conta, ela herda o titular, Saldo e Depósito
    public class ContaCorrente : Conta
    {

        private const decimal Limite = 200; //limite especial
        public ContaCorrente(string titular, decimal saldoInicial) : base(titular, saldoInicial)
        //repasse os dados para o construtor da base
        {
            
        }

        public override void Sacar(decimal valor)

        //POLIMORFISMO
        //a maneira como a corrente saca, pode usar o limite especial
        {
            if (valor > (this.Saldo + Limite))
            {
                throw new ArgumentException("Saldo insuficiente para efetuar a transação!");
            } else
            {
                this.Saldo = this.Saldo-valor;
                Console.WriteLine($"Transação realizada! Seu novo saldo é de R${this.Saldo}");
            }
        }
    }
}