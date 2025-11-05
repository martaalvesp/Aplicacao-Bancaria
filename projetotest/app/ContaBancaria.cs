using System;

namespace AplicacaoBancaria
{
    public class ContaBancaria
    {
        public int Numero { get; private set; }
        public decimal Saldo { get; private set; }

        private readonly Cliente Titular;

        public ContaBancaria(int numero, Cliente titular)
        {
            Numero = numero;
            Titular = titular;
            Saldo = 0;
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor de depósito inválido.");
                return;
            }

            Saldo += valor;
            Console.WriteLine($"Depósito de R${valor:F2} realizado. Novo saldo: R${Saldo:F2}");
        }

        public bool Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor de saque inválido.");
                return false;
            }

            if (valor <= Saldo)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de R${valor:F2} realizado. Novo saldo: R${Saldo:F2}");
                return true;
            }
            else
            {
                Console.WriteLine("Saldo insuficiente.");
                return false;
            }
        }

        public void ExibirDadosConta()
        {
            Console.WriteLine($"Conta Nº: {Numero} | Saldo: R${Saldo:F2}");
            Titular.ExibirDados();
        }
         
        public void GerarRelatorio()
        {
            Relatorio relatorio = new Relatorio();
            relatorio.GerarExtrato(this);
        }
    }
}
