using System;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes
{
    public class PontuacaoDaFamiliaDTO
    {
        public Guid FamiliaId { get; set; }
        public int Pontuacao { get; set; }
        public int CriteriosAtendidos { get; set; }
    }
}
