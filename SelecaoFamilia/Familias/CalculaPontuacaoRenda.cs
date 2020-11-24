using System;
using System.Collections.Generic;
using System.Text;

namespace SelecaoFamilia.Dominio.Familias
{
    class CalculaPontuacaoRenda : ICalculaPontuacao
    {
        public int CalcularPontuacao(Familia familia)
        {
            decimal renda = 0;

            foreach(var pessoa in familia.Pessoas)
                renda += pessoa.Renda;
            
            switch(renda)
            {
                case decimal n when n <= 900.00M : return 5;
                case decimal n when n >= 900.01M && n <= 1500.00M : return 3;
                case decimal n when n >= 1500.01M && n <= 2000.00M : return 1;
                default: return 0;
            }
        }
    }
}
