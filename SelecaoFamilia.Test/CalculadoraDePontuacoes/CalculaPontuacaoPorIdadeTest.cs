using SelecaoFamilia.Dominio.CalculadoraDePontuacoes;
using SelecaoFamilia.Dominio.Familias.Pessoas;
using SelecaoFamilia.Test._Builders;
using System;
using Xunit;

namespace SelecaoFamilia.Test.CalculadoraDePontuacoes
{
    public class CalculaPontuacaoPorIdadeTest
    {
        [Theory]
        [InlineData("1982-12-31", 2)]
        [InlineData("1970-12-31", 3)]
        [InlineData("2005-12-31", 1)]
        public void DeveCalcularPontuacaoPorIdade(DateTime dataNascimento, int pontuacaoEsperada)
        {
            var pessoaPretendente = PessoaBuilder.Novo().ComDataDeNascimento(dataNascimento).Build();
            var familia = FamiliaBuilder.Novo().ComPessoa(pessoaPretendente).Build();
            var calculaPontuacaoPorIdade = new CalculaPontuacaoPorIdade();

            var pontuacao = calculaPontuacaoPorIdade.CalcularPontuacao(familia);

            Assert.Equal(pontuacaoEsperada, pontuacao);
        }

        [Theory]
        [InlineData(500.00, 400.00, 5)]
        [InlineData(900.00, 0.00, 5)]
        [InlineData(1000.00, 1000.00, 1)]
        [InlineData(1000.00, 900.00, 1)]
        [InlineData(3000.00, 0.00, 0)]
        [InlineData(2001.00, 0.00, 0)]
        public void DeveCalcularPontuacaoPorRenda(decimal rendaPretendente, decimal rendaConjuge, int pontuacaoEsperada)
        {
            var pessoaPretendente = PessoaBuilder.Novo().ComRenda(rendaPretendente).Build();
            var pessoaConjuge = PessoaBuilder.Novo().ComRenda(rendaConjuge).ComTipoPessoa(TipoPessoa.Conjuge).Build();
            var familia = FamiliaBuilder.Novo().ComPessoa(pessoaPretendente).Build();
            familia.AdicionarPessoa(pessoaConjuge);
            var calculadoraDePontuacao = new CalcadoraDeCriteriosDaFamilia(familia);

            var pontuacao = calculadoraDePontuacao.CalcularPorRenda();

            Assert.Equal(pontuacaoEsperada, pontuacao);
        }
    }
}
