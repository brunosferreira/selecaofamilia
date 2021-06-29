using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes.PorRenda
{
    public interface ICalculaPontuacaoPorRenda
    {
        public int CalculaPontuacao(Familia familia);
    }
}
