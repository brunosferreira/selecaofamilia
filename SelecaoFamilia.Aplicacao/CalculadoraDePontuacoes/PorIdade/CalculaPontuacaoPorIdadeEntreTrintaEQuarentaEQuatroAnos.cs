using System.Linq;
using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes.PorIdade
{
    public class CalculaPontuacaoPorIdadeEntreTrintaEQuarentaEQuatroAnos : ICalculaPontuacaoPorIdade
    {
        public int CalculaPontuacao(Familia familia)
        {
            return Enumerable.Range(30, 14).Contains(familia.Pretendente.Idade) ? 2 : 0;
        }
    }
}
