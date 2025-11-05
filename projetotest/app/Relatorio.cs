using System;

namespace AplicacaoBancaria
{
    public class Relatorio
    {
        public void GerarExtrato(ContaBancaria contaextrato)
        {
            Console.WriteLine("\n~ RELATÓRIO: EXTRATO BANCÁRIO ~");
            contaextrato.ExibirDadosConta();
        }
    }

}

