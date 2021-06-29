using SelecaoFamilia.Dominio.Familias;
using System.Linq;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes.PorRenda
{
    public class CalculaPontuacaoPorRendaAteNovecentos : ICalculaPontuacaoPorRenda
    {
        public readonly decimal _rendaDeReferencia = 900.00M;
        public int CalculaPontuacao(Familia familia)
        {
            return familia.Pessoas.Sum(pessoa => pessoa.Renda) <= 900 ? 5 : 0;
        }
    }
}
