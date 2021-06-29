using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes.PorIdade
{
    public class CalculaPontuacaoPorIdadeQuarentaECincoAnosOuMais : ICalculaPontuacaoPorIdade
    {
        public int CalculaPontuacao(Familia familia)
        {
            return familia.Pretendente.Idade >= 45 ? 3 : 0;
        }
    }
}
