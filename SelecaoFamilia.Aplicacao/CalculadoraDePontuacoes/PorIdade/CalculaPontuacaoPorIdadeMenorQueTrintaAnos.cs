﻿using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes.PorIdade
{
    public class CalculaPontuacaoPorIdadeMenorQueTrintaAnos : ICalculaPontuacaoPorIdade
    {
        public int CalculaPontuacao(Familia familia)
        {
            return familia.Pretendente.Idade < 30 ? 1 : 0;
        }
    }
}
