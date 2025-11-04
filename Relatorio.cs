using System;

namespace AplicacaoBancaria
{
    public class Relatorio
    {
        public void GerarExtrato(ContaBancaria conta)
        {
            Console.WriteLine("\nEXTRATO BANCÁRIO");
            conta.ExibirDadosConta();
        }
    }

}
