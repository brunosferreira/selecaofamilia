using SelecaoFamilia.Dominio.Familias;
using SelecaoFamilia.Dominio.Familias.Contemplados;
using SelecaoFamilia.Test._Builders;
using System;
using Xunit;

namespace SelecaoFamilia.Test.Familias.Contemplados
{
    public class ContempladoTest
    {
        [Fact]
        public void DeveCriarUmContemplado()
        {
            var familiaEsperada = FamiliaBuilder.Novo().Build();
            
            var Contemplado = new Contemplado(familiaEsperada);

            Assert.Equal(familiaEsperada, Contemplado.PontuacaoFamilia.Familia);
        }

        [Fact]
        public void NaoDeveContempladoTerFamiliaInvalida()
        {
            Assert.Throws<ArgumentException>(() => new Contemplado(null));
        }

        [Fact]
        public void DeveCriarContempladoComADataDeHoje()
        {
            var dataEsperada = DateTime.Today;

            var Contemplado = new Contemplado(FamiliaBuilder.Novo().Build());

            Assert.Equal(dataEsperada, Contemplado.Data);
        }

        [Theory]
        [InlineData(StatusFamilia.CadastroIncompleto)]
        [InlineData(StatusFamilia.JaPossuiCasa)]
        [InlineData(StatusFamilia.SelecionadaEmOutroProcesso)]
        public void NaoDeveContempladoTerFamiliaComCadastroInvalido(StatusFamilia status)
        {
            Assert.Throws<ArgumentException>(() => new Contemplado(FamiliaBuilder.Novo().ComStatus(status).Build()));
        }
    }
}
