using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes.PorRenda
{
    public interface ICalculaPontuacaoPorRenda
    {
        public int CalculaPontuacao(Familia familia);
    }
}
