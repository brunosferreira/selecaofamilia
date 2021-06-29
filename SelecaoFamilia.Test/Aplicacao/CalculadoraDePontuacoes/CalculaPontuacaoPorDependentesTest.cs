using SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes;
using SelecaoFamilia.Dominio.Familias.Pessoas;
using SelecaoFamilia.Test._Builders;
using Xunit;

namespace SelecaoFamilia.Test.Aplicacao.CalculadoraDePontuacoes
{
    public class CalculaPontuacaoPorDependentesTest
    {
        [Theory]
        [InlineData(3, 3)]
        [InlineData(2, 2)]
        [InlineData(1, 2)]
        [InlineData(0, 0)]
        public void DeveCalcularPontuacaoPorDependente(int dependenteMenorDeIdade, int pontuacaoEsperada)
        {
            var pessoaPretendente = PessoaBuilder.Novo().Build();
            var pessoaConjuge = PessoaBuilder.Novo().ComTipoPessoa(TipoPessoa.Conjuge).Build();
            var familia = FamiliaBuilder.Novo().ComPessoa(pessoaPretendente).Build();
            familia.AdicionarPessoa(pessoaConjuge);

            for (var i = 0; i < dependenteMenorDeIdade; i++)
            {
                var dependente = PessoaBuilder.Novo().ComTipoPessoa(TipoPessoa.Dependente).ComMenorDeIdade().ComRenda(0.00M).Build();
                familia.AdicionarPessoa(dependente);
            }

            var calculaPontuacaoPorDependentes = new CalculaPontuacaoPorDependentes();
            var pontucao = calculaPontuacaoPorDependentes.CalcularPontuacao(familia);

            Assert.Equal(pontuacaoEsperada, pontucao);
        }
    }
}
