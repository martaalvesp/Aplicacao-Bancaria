using System;

namespace AplicacaoBancaria
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }

        public void ExibirDados()
        {
            Console.WriteLine($"Cliente: {Nome} | CPF: {Cpf}");
        }
    }
}
