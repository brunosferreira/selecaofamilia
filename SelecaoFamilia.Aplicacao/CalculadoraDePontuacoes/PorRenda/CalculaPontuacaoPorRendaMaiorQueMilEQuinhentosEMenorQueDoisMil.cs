using SelecaoFamilia.Dominio.Familias;
using System;
using System.Linq;

namespace SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes.PorRenda
{
    class CalculaPontuacaoPorRendaMaiorQueMilEQuinhentosEMenorQueDoisMil : ICalculaPontuacaoPorRenda
    {
        private readonly decimal _menorRenda = 1500M;
        private readonly decimal _maiorRenda = 2000M;

        public int CalculaPontuacao(Familia familia)
        {
            var renda = familia.Pessoas.Sum(pessoa => pessoa.Renda);
            return renda >= _menorRenda && renda <= _maiorRenda ? 1 : 0;
        }
    }
}
