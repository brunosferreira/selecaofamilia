using SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes;
using SelecaoFamilia.Dominio.Familias.Pessoas;
using SelecaoFamilia.Test._Builders;
using System;
using Xunit;

namespace SelecaoFamilia.Test.Aplicacao.CalculadoraDePontuacoes
{
    public class CalculadoraDeCriteriosDaFamiliaTest
    {
        [Fact]
        public void DeveCalcularUmaFamiliaQuePontuaEmTodosOsCriterios()
        {
            const int pontuacaoEsperada = 7;
            var familia = FamiliaBuilder.Novo().ComPessoa(
                PessoaBuilder.Novo().ComTipoPessoa(TipoPessoa.Pretendente).ComRenda(1000.00M).ComDataDeNascimento(new DateTime(1982, 12, 31)).Build()).Build();
            for (var i = 0; i < 1; i++)
            {
                var dependente = PessoaBuilder.Novo().ComTipoPessoa(TipoPessoa.Dependente).ComMenorDeIdade().ComRenda(0.00M).Build();
                familia.AdicionarPessoa(dependente);
            }
            var calcadoraDeCriteriosDaFamilia = new CalculadoraDePontuacao();

            var pontuacaoDaFamiliaDTO = calcadoraDeCriteriosDaFamilia.Calcula(familia);

            Assert.Equal(pontuacaoEsperada, pontuacaoDaFamiliaDTO.Pontuacao);
        }
    }
}
