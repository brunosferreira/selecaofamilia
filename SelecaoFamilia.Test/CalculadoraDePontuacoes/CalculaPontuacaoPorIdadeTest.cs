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
    }
}
