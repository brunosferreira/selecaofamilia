using System;
using System.Collections.Generic;
using System.Text;

namespace SelecaoFamilia.Dominio.Familias
{
    public class CalculaPontuacaoIdade : ICalculaPontuacao
    {
        public int CalcularPontuacao(Familia familia)
        {
            var pretendente = familia.Pretendente;

            switch (pretendente.Idade)
            {
                case int n when (n < 30):
                    return 1;
                case int n when (n >= 30 && n <= 44):                
                    return 2;
                default:
                    return 3;
            }
        }
    }
}
