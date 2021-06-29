using SelecaoFamilia.Dominio.CalculadoraDePontuacoes.PorIdade;
using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes
{
    public class CalculaPontuacaoPorIdade : ICalculaPontuacaoPorIdade
    {
        private readonly CalculaPontuacaoPorIdadeEntreTrintaEQuarentaEQuatroAnos _calculaPontuacaoPorIdadeEntreTrintaEQuarentaEQuatroAnos;
        private readonly CalculaPontuacaoPorIdadeMenorQueTrintaAnos _calculaPontuacaoPorIdadeMenorQueTrintaAnos;
        private readonly CalculaPontuacaoPorIdadeQuarentaECincoAnosOuMais _calculaPontuacaoPorIdadeQuarentaECincoAnosOuMais;

        public CalculaPontuacaoPorIdade()
        {
            _calculaPontuacaoPorIdadeEntreTrintaEQuarentaEQuatroAnos = new CalculaPontuacaoPorIdadeEntreTrintaEQuarentaEQuatroAnos();
            _calculaPontuacaoPorIdadeMenorQueTrintaAnos = new CalculaPontuacaoPorIdadeMenorQueTrintaAnos();
            _calculaPontuacaoPorIdadeQuarentaECincoAnosOuMais = new CalculaPontuacaoPorIdadeQuarentaECincoAnosOuMais();
        }

        public int CalcularPontuacao(Familia familia)
        {
            return _calculaPontuacaoPorIdadeEntreTrintaEQuarentaEQuatroAnos.CalculaPontuacao(familia) +
                _calculaPontuacaoPorIdadeMenorQueTrintaAnos.CalculaPontuacao(familia) +
                _calculaPontuacaoPorIdadeQuarentaECincoAnosOuMais.CalculaPontuacao(familia);
        }
    }
}
