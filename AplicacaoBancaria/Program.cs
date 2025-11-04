using AplicacaoBancaria;
using System;

namespace AplicacaoBancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Contas Bancárias");

            Console.WriteLine("Digite o nome do cliente: ");
            string nome = Console.ReadLine();

            static string MaxCpf()
            {
                while (true)
                {

                    Console.WriteLine("Digite o CPF do cliente: ");
                    string cpf = Console.ReadLine();

                    if (cpf.Length != 11)
                    {
                        Console.WriteLine("CPF inválido. Deve conter 11 dígitos.");
                        continue;
                    }
                    return cpf;
                }
            }

            string cpf = MaxCpf();

            Cliente cliente = new Cliente(nome, cpf);

            Random random = new Random();
            ContaBancaria conta = new ContaBancaria(random.Next(1000, 9999), cliente);

            Console.WriteLine($"Conta criada com sucesso! Número da conta: {conta.Numero}");

            int opcao = 0;
            do {                 
                Console.WriteLine("\nEscolha uma operação:");
                Console.WriteLine("1 - Depositar");
                Console.WriteLine("2 - Sacar");
                Console.WriteLine("3 - Gerar Extrato");
                Console.WriteLine("4 - Sair");
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o valor para depósito: R$");
                        decimal valorDeposito = decimal.Parse(Console.ReadLine());
                        conta.Depositar(valorDeposito);
                        break;
                    case 2:
                        Console.Write("Digite o valor para saque: R$");
                        decimal valorSaque = decimal.Parse(Console.ReadLine());
                        conta.Sacar(valorSaque);
                        break;
                    case 3:
                        Relatorio relatorio = new Relatorio();
                        relatorio.GerarExtrato(conta);
                        break;
                    case 4:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (opcao != 4);

            Console.WriteLine("Operações concluídas.\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
