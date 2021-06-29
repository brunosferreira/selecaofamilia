using SelecaoFamilia.Dominio.CalculadoraDePontuacoes.PorRenda;
using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes
{
    public class CalculaPontuacaoPorRenda : ICalculaPontuacaoPorIdade
    {
        private readonly CalculaPontuacaoPorRendaMaiorQueMilEQuinhentosEMenorQueDoisMil _calculaPontuacaoPorRendaMaiorQueMilEQuinhentosEMenosQueDoisMil;
        private readonly CalculaPontuacaoPorRendaMaiorQueNovecentosEMenorQueMilEQuinhentos _calculaPontuacaoPorRendaMaiorQueNovecentosEMenorQueMilEQuinhentos;
        private readonly CalculaPontuacaoPorRendaAteNovecentos _calculaPontuacaoPorRendaAteNovecentos;

        public CalculaPontuacaoPorRenda()
        {
            _calculaPontuacaoPorRendaMaiorQueMilEQuinhentosEMenosQueDoisMil = new CalculaPontuacaoPorRendaMaiorQueMilEQuinhentosEMenorQueDoisMil();
            _calculaPontuacaoPorRendaMaiorQueNovecentosEMenorQueMilEQuinhentos = new CalculaPontuacaoPorRendaMaiorQueNovecentosEMenorQueMilEQuinhentos();
            _calculaPontuacaoPorRendaAteNovecentos = new CalculaPontuacaoPorRendaAteNovecentos();
        }

        public int CalcularPontuacao(Familia familia)
        {
            return _calculaPontuacaoPorRendaAteNovecentos.CalculaPontuacao(familia) +
                _calculaPontuacaoPorRendaMaiorQueMilEQuinhentosEMenosQueDoisMil.CalculaPontuacao(familia) +
                _calculaPontuacaoPorRendaMaiorQueNovecentosEMenorQueMilEQuinhentos.CalculaPontuacao(familia);
        }
    }
}
