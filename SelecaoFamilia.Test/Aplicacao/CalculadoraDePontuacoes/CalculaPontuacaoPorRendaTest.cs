using SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes;
using SelecaoFamilia.Dominio.Familias.Pessoas;
using SelecaoFamilia.Test._Builders;
using Xunit;

namespace SelecaoFamilia.Test.Aplicacao.CalculadoraDePontuacoes
{
    public class CalculaPontuacaoPorRendaTest
    {
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
            var calculaPontuacaoPorRenda = new CalculaPontuacaoPorRenda();

            var pontuacao = calculaPontuacaoPorRenda.CalcularPontuacao(familia);

            Assert.Equal(pontuacaoEsperada, pontuacao);
        }
    }
}
