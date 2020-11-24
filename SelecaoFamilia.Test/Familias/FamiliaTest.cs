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

            var familia = new Familia(familiaEsperada.Id, familiaEsperada.Pretendente, familiaEsperada.Status);

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

        [Fact]
        public void DeveCriarFamiliaComPontuacaoZerada()
        {
            var pontuacaoEsperada = 0;

            var familia = FamiliaBuilder.Novo().Build();

            Assert.Equal(pontuacaoEsperada, familia.Pontuacao);
        }

        [Fact]
        public void DeveCriarFamiliaComCriteriosAtendidosZerado()
        {
            var criteriosAtendidosEsperado = 0;

            var familia = FamiliaBuilder.Novo().Build();

            Assert.Equal(criteriosAtendidosEsperado, familia.Pontuacao);
        }

        [Theory]
        [InlineData("1985-6-30", 1000.00, 1000.00, 3, 2, 0)]
        [InlineData("1989-12-31", 2000.00, 1000.00, 2, 1, 0)]
        [InlineData("1975-7-15", 800.00, 0.00, 7, 2, 0)]
        [InlineData("1975-2-20", 800.00, 0.00, 9, 3, 1)]
        [InlineData("2020-1-1", 2000.00, 2500.00, 1, 1, 0)]
        public void DeveFamiliaCalcularPontuacao(DateTime DataNascimento, decimal rendaPretendente, decimal rendaConjuge, int pontuacaoEsperada,
            int criteriosAtendidosEsperado, int dependenteMenorDeIdade)
        {
            var pessoaPretendente = PessoaBuilder.Novo().ComDataDeNascimento(DataNascimento).ComRenda(rendaPretendente).Build();
            var pessoaConjuge = PessoaBuilder.Novo().ComRenda(rendaConjuge).ComTipoPessoa(TipoPessoa.Conjuge).Build();
            var familia = FamiliaBuilder.Novo().ComPessoa(pessoaPretendente).Build();
            familia.AdicionarPessoa(pessoaConjuge);

            for(var i = 0; i < dependenteMenorDeIdade; i++)
            {
                var dependente = PessoaBuilder.Novo().ComTipoPessoa(TipoPessoa.Dependente).ComMenorDeIdade().ComRenda(0.00M).Build();
                familia.AdicionarPessoa(dependente);
            }

            familia.CalcularPontuacao();

            Assert.Equal(pontuacaoEsperada, familia.Pontuacao);
            Assert.Equal(criteriosAtendidosEsperado, familia.CriteriosAtendidos);
        }
    }
}
