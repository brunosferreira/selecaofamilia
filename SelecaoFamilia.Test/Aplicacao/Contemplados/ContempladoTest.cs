using SelecaoFamilia.Dominio.Familias;
using SelecaoFamilia.Aplicacao.Contemplados;
using SelecaoFamilia.Test._Builders;
using System;
using Xunit;
using Moq;
using SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes;

namespace SelecaoFamilia.Test.Aplicacao.Contemplados
{
    public class ContempladoTest
    {
        private readonly Contemplado _contemplado;
        private readonly Mock<ICalculadoraDePontuacao> _calculadoraDePontuacaoMock;

        public ContempladoTest()
        {
            _calculadoraDePontuacaoMock = new Mock<ICalculadoraDePontuacao>();
            _contemplado = new Contemplado(_calculadoraDePontuacaoMock.Object);
        }

        [Fact]
        public void DeveCriarUmContemplado()
        {
            var familiaEsperada = FamiliaBuilder.Novo().Build();

            _contemplado.AdicionaFamilia(familiaEsperada);

            Assert.Equal(familiaEsperada, _contemplado.Familia);
        }

        [Fact]
        public void NaoDeveContempladoTerFamiliaInvalida()
        {
            Assert.Throws<ArgumentException>(() => _contemplado.AdicionaFamilia(null));
        }

        [Fact]
        public void DeveCriarContempladoComADataDeHoje()
        {
            var dataEsperada = DateTime.Today;

            Assert.Equal(dataEsperada, _contemplado.Data);
        }

        [Theory]
        [InlineData(StatusFamilia.CadastroIncompleto)]
        [InlineData(StatusFamilia.JaPossuiCasa)]
        [InlineData(StatusFamilia.SelecionadaEmOutroProcesso)]
        public void NaoDeveContempladoTerFamiliaComCadastroInvalido(StatusFamilia status)
        {
            Assert.Throws<ArgumentException>(() => _contemplado.AdicionaFamilia(FamiliaBuilder.Novo().ComStatus(status).Build()));
        }
    }
}
