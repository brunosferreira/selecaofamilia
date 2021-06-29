using SelecaoFamilia.Dominio.Familias;
using System.Linq;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes.PorRenda
{
    public class CalculaPontuacaoPorRendaMaiorQueNovecentosEMenorQueMilEQuinhentos : ICalculaPontuacaoPorRenda
    {
        private readonly decimal _rendaMinima = 900M;
        private readonly decimal _rendaMaxima = 1500M;
        public int CalculaPontuacao(Familia familia)
        {
            var renda = familia.Pessoas.Sum(pessoa => pessoa.Renda);
            return renda > _rendaMinima && renda < _rendaMaxima ? 3 : 0;
        }       
    }
}
