using System;

namespace SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes
{
    public class PontuacaoDaFamiliaDTO
    {
        public Guid Id { get; set; }
        public int Pontuacao { get; set; }
        public int CriteriosAtendidos { get; set; }
    }
}
