using SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes.PorDependentes;
using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes
{
    public class CalculaPontuacaoPorDependentes : ICalculaPontuacao
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
