using System;
using System.Collections.Generic;
using System.Text;

namespace SelecaoFamilia.Dominio.Familias
{
    public interface ICalculaPontuacao
    {
        public int CalcularPontuacao(Familia familia);
    }
}
