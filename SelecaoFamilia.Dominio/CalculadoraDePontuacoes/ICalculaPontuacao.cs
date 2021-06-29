
using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes
{
    public interface ICalculaPontuacaoPorIdade
    {
        public int CalcularPontuacao(Familia familia);
    }
}
