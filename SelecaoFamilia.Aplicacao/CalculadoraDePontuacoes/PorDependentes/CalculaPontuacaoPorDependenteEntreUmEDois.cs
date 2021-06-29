using SelecaoFamilia.Dominio.Familias;
using SelecaoFamilia.Dominio.Familias.Pessoas;
using System;
using System.Linq;

namespace SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes.PorDependentes
{
    class CalculaPontuacaoPorDependenteEntreUmEDois : ICalculaPontuacaoPorDependente
    {
        private readonly int _menorQuantidade = 1;
        private readonly int _maiorQuantidade = 2;

        public int CalculaPontuacao(Familia familia)
        {
            var quantidadeDeDependentes = familia.Pessoas.Where(pessoa => pessoa.TipoPessoa == TipoPessoa.Dependente).Count();
            return quantidadeDeDependentes >= _menorQuantidade && quantidadeDeDependentes <= _maiorQuantidade ? 2 : 0;
        }
    }
}
