// Instanciar um objeto da classe "Banco"
using Services;
using SISTEMA_BANCARIO.Models;

Banco banco = new();

banco.Adicionar(new ContaCorrente("Samuel",540000));
banco.Adicionar(new ContaPoupanca("Laura",25000));

banco.ProcessarMovimentacoes();























































































































































// using System;

// namespace SISTEMA_BANCARIO.Models
// {
//     public class Program
//     {
//         static void Main()
//         {
//             Console.WriteLine("Informe o nome completo: ");
//             string nome = Console.ReadLine()!;
//             Console.WriteLine("Informe o saldo da conta: ");
//             decimal dinheiro = decimal.Parse(Console.ReadLine()!);

//             int opcao = 0;

//             do
//             {
//             Console.WriteLine("Informe se a conta é corrente ou poupança:\n1-Corrente\n2-Poupança");
//             opcao = int.Parse(Console.ReadLine()!);
//                 if (opcao != 1 && opcao !=2)
//                 {
//                     Console.WriteLine("Opção invlaída!\n-----------------------------------------");
//                 }
//             } while (opcao != 1 && opcao !=2);

//             Console.Write("Informe o valor a ser sacado: ");
//             decimal valor = decimal.Parse(Console.ReadLine()!);

//             if (opcao == 1)
//             {
//                 ContaCorrente corrente = new ContaCorrente(nome, dinheiro);

//                 corrente.Sacar(valor);
//             }
//             if (opcao == 2)
//             {
                
//             }
//         }
//     }
// }