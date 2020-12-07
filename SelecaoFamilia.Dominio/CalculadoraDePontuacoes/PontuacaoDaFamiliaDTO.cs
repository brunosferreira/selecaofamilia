using System;
using System.Collections.Generic;
using System.Text;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes
{
    public class PontuacaoDaFamiliaDTO
    {
        public Guid FamiliaId { get; set; }
        public int Pontuacao { get; set; }
        public int CriteriosAtendidos { get; set; }
    }
}
