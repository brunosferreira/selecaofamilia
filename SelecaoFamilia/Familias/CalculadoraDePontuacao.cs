using System;
using System.Collections.Generic;
using System.Text;

namespace SelecaoFamilia.Dominio.Familias
{
    public class CalculadoraDePontuacao
    {
        private readonly ICalculaPontuacao CalculaPontuacaoFamilia;

        public CalculadoraDePontuacao(ICalculaPontuacao calculaPontuacaoFamilia)
        {
            CalculaPontuacaoFamilia = calculaPontuacaoFamilia;
        }

        public int Calcular(Familia familia)
        {
            return CalculaPontuacaoFamilia.CalcularPontuacao(familia);
        }
    }
}
