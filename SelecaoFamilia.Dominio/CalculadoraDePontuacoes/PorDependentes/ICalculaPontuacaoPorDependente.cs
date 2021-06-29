using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes.PorDependentes
{
    public interface ICalculaPontuacaoPorDependente
    {
        public int CalculaPontuacao(Familia familia);
    }
}
