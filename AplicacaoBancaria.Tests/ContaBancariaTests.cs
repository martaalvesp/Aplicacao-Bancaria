using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplicacaoBancaria; // Importa o namespace do projeto principal

namespace AplicacaoBancaria.Tests
{
    [TestClass]
    public class ContaBancariaTests
    {
        private Cliente _clientePadrao = null!; // Correção do erro CS8618

        [TestInitialize]
        public void Setup()
        {
            _clientePadrao = new Cliente("Cliente Teste", "12345678901");
        }

        [TestMethod]
        public void Depositar_ComValorPositivo_DeveAtualizarSaldo()
        {
            ContaBancaria conta = new ContaBancaria(1001, _clientePadrao);
            decimal valorDeposito = 100.50m;
            decimal saldoEsperado = 100.50m;

            conta.Depositar(valorDeposito);

            Assert.AreEqual(saldoEsperado, conta.Saldo);
        }

        [TestMethod]
        public void Depositar_ComValorNegativo_NaoDeveAlterarSaldo()
        {
            ContaBancaria conta = new ContaBancaria(1002, _clientePadrao);
            decimal valorDeposito = -50.00m;
            decimal saldoEsperado = 0.00m;

            conta.Depositar(valorDeposito);

            Assert.AreEqual(saldoEsperado, conta.Saldo);
        }

        [TestMethod]
        public void Depositar_ComValorZero_NaoDeveAlterarSaldo()
        {
            ContaBancaria conta = new ContaBancaria(1002, _clientePadrao);
            decimal valorDeposito = 0m;
            decimal saldoEsperado = 0.00m;

            conta.Depositar(valorDeposito);

            Assert.AreEqual(saldoEsperado, conta.Saldo);
        }

        [TestMethod]
        public void Sacar_ComSaldoSuficiente_DeveAtualizarSaldoERetornarTrue()
        {
            ContaBancaria conta = new ContaBancaria(1003, _clientePadrao);
            conta.Depositar(200.00m);

            decimal valorSaque = 150.00m;
            decimal saldoEsperado = 50.00m;

            bool resultado = conta.Sacar(valorSaque);

            Assert.IsTrue(resultado);
            Assert.AreEqual(saldoEsperado, conta.Saldo);
        }

        [TestMethod]
        public void Sacar_ComSaldoInsuficiente_NaoDeveAlterarSaldoERetornarFalse()
        {
            ContaBancaria conta = new ContaBancaria(1004, _clientePadrao);
            conta.Depositar(100.00m);

            decimal valorSaque = 150.00m;
            decimal saldoEsperado = 100.00m;

            bool resultado = conta.Sacar(valorSaque);

            Assert.IsFalse(resultado);
            Assert.AreEqual(saldoEsperado, conta.Saldo);
        }

        [TestMethod]
        public void Sacar_ComValorNegativo_NaoDeveAlterarSaldoERetornarFalse()
        {
            ContaBancaria conta = new ContaBancaria(1005, _clientePadrao);
            conta.Depositar(100.00m);

            decimal valorSaque = -50.00m;
            decimal saldoEsperado = 100.00m;

            bool resultado = conta.Sacar(valorSaque);

            Assert.IsFalse(resultado);
            Assert.AreEqual(saldoEsperado, conta.Saldo);
        }

        [TestMethod]
        public void Sacar_ComValorZero_NaoDeveAlterarSaldoERetornarFalse()
        {
            ContaBancaria conta = new ContaBancaria(1006, _clientePadrao);
            conta.Depositar(100.00m);

            decimal valorSaque = 0m;
            decimal saldoEsperado = 100.00m;

            bool resultado = conta.Sacar(valorSaque);

            Assert.IsFalse(resultado);
            Assert.AreEqual(saldoEsperado, conta.Saldo);
        }
    }
}