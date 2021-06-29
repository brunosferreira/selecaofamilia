using ExpectedObjects;
using SelecaoFamilia.Dominio.Familias;
using SelecaoFamilia.Dominio.Familias.Pessoas;
using SelecaoFamilia.Test._Builders;
using System;
using Xunit;

namespace SelecaoFamilia.Test.Familias
{
    public class FamiliaTest
    {
        [Fact]
        public void DeveCriarFamilia()
        {
            var familiaEsperada = FamiliaBuilder.Novo().Build();

            var familia = new Familia(familiaEsperada.Pretendente, familiaEsperada.Status);

            familiaEsperada.ToExpectedObject().ShouldMatch(familia);
        }

        [Fact]
        public void NaoDeveFamiliaAdicionarPessoaPretendente()
        {
            Pessoa pessoaPretendente = PessoaBuilder.Novo().ComNome("Maria").Build();
            Pessoa pessoaPretendente2 = PessoaBuilder.Novo().ComNome("João").Build();

            Familia familia = FamiliaBuilder.Novo().ComPessoa(pessoaPretendente).Build();

            Assert.Throws<ArgumentException>(() => familia.AdicionarPessoa(pessoaPretendente2));
        }

        [Fact]
        public void NaoDeveCriarFamiliaComPessoaNaoPretendente()
        {
            var pessoa = PessoaBuilder.Novo().ComTipoPessoa(TipoPessoa.Conjuge).Build();
            Assert.Throws<ArgumentException>(() => FamiliaBuilder.Novo().ComPessoa(pessoa).ComStatus(StatusFamilia.CadastroValido).Build());
        }
    }
}
