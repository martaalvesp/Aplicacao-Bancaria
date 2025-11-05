using System;
using System.Linq;
using AplicacaoBancaria;

namespace AplicacaoBancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Contas Bancárias");

            string nome = LerNome();
            string cpf = LerCpf();

            Cliente cliente = new Cliente(nome, cpf);
            ContaBancaria conta = new ContaBancaria(new Random().Next(1000, 9999), cliente);

            Console.WriteLine($"\nConta criada com sucesso! Número da conta: {conta.Numero}");

            int opcao;
            do
            {
                Console.WriteLine("\n1 - Depositar\n2 - Sacar\n3 - Gerar Extrato\n4 - Sair");
                Console.Write("Opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Digite um número válido!");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        Console.Write("Valor para depósito: R$");
                        if (decimal.TryParse(Console.ReadLine(), out decimal dep) && dep > 0)
                            conta.Depositar(dep);
                        else
                            Console.WriteLine("Valor inválido.");
                        break;

                    case 2:
                        Console.Write("Valor para saque: R$");
                        if (decimal.TryParse(Console.ReadLine(), out decimal saq) && saq > 0)
                            conta.Sacar(saq);
                        else
                            Console.WriteLine("Valor inválido.");
                        break;

                    case 3:
                        new Relatorio().GerarExtrato(conta);
                        break;

                    case 4:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcao != 4);
        }
        static string LerNome()
        {
            while (true)
            {
                Console.Write("Digite o nome do cliente: ");
                string nome = Console.ReadLine()?.Trim() ?? "";

                if (!string.IsNullOrEmpty(nome) && nome.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    return nome;

                Console.WriteLine("Nome inválido, use apenas letras e espaços.");
            }
        }

        static string LerCpf()
        {
            while (true)
            {
                Console.Write("Digite o CPF do cliente: ");
                string cpf = Console.ReadLine()?.Trim() ?? "";

                if (cpf.Length == 11 && cpf.All(char.IsDigit))
                    return cpf;

                Console.WriteLine("CPF inválido, digite 11 números.");
            }
        }
    }
}
