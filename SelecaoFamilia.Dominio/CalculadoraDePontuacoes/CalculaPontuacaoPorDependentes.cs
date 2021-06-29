using SelecaoFamilia.Dominio.CalculadoraDePontuacoes.PorDependentes;
using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes
{
    public class CalculaPontuacaoPorDependentes : ICalculaPontuacaoPorIdade
    {
        private readonly CalculaPontuacaoPorDependenteEntreUmEDois _calculaPontuacaoPorDependenteEntreUmEDois;
        private readonly CalculaPontuacaoPorDependenteTresOuMais _calculaPontuacaoPorDependenteTresOuMais;

        public CalculaPontuacaoPorDependentes()
        {
            _calculaPontuacaoPorDependenteEntreUmEDois = new CalculaPontuacaoPorDependenteEntreUmEDois();
            _calculaPontuacaoPorDependenteTresOuMais = new CalculaPontuacaoPorDependenteTresOuMais(); ;
        }

        public int CalcularPontuacao(Familia familia)
        {
            return _calculaPontuacaoPorDependenteEntreUmEDois.CalculaPontuacao(familia) +
                _calculaPontuacaoPorDependenteTresOuMais.CalculaPontuacao(familia);
        }
    }
}
