using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes.PorDependentes
{
    public interface ICalculaPontuacaoPorDependente
    {
        public int CalculaPontuacao(Familia familia);
    }
}
