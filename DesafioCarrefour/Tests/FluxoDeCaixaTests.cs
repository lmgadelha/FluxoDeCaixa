namespace FluxoDeCaixa.Tests
{
    using FluxoDeCaixa.Controllers;
    using FluxoDeCaixa.Models;
    using NUnit.Framework;

    [TestFixture]
    public class FluxoDeCaixaTests
    {
        private FluxoDeCaixa fluxoDeCaixa;

        [SetUp]
        public void Setup()
        {
            // Configurar o ambiente de teste
            // Isso pode incluir a criação de objetos, inicialização do banco de dados de teste, etc.
            fluxoDeCaixa = new FluxoDeCaixa();
        }

        [Test]
        public void RegistrarLancamento_DeveIncrementarSaldoParaCreditos()
        {
            // Arrange
            decimal saldoInicial = 100;
            decimal valorLancamento = 50;

            fluxoDeCaixa.SaldoDiario = saldoInicial;

            // Act
            fluxoDeCaixa.RegistrarLancamento(TipoLancamento.Credito, valorLancamento);

            // Assert
            decimal saldoEsperado = saldoInicial + valorLancamento;
            Assert.AreEqual(saldoEsperado, fluxoDeCaixa.SaldoDiario);
        }

        [Test]
        public void RegistrarLancamento_DeveDecrementarSaldoParaDebitos()
        {
            // Arrange
            decimal saldoInicial = 100;
            decimal valorLancamento = 50;

            fluxoDeCaixa.SaldoDiario = saldoInicial;

            // Act
            fluxoDeCaixa.RegistrarLancamento(TipoLancamento.Debito, valorLancamento);

            // Assert
            decimal saldoEsperado = saldoInicial - valorLancamento;
            Assert.AreEqual(saldoEsperado, fluxoDeCaixa.SaldoDiario);
        }
    }
}
