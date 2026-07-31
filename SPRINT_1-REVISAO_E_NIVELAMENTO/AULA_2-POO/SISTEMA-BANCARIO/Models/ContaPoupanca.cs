using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISTEMA_BANCARIO.Models
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(string titular, decimal saldoInicial):base(titular, saldoInicial)
        {
            
        }

        public override void Sacar(decimal valor)
        {
            if (valor>this.Saldo)
            {
            throw new ArgumentException("Saldo insuficiente para efetuar a transação!");  
            }
            else
            {
                this.Saldo = this.Saldo-valor;
                Console.WriteLine($"Transação realizada! Seu novo saldo é de R$ {this.Saldo}");
            }
        }
    }
}