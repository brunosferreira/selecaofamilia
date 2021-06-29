using System.Linq;
using SelecaoFamilia.Dominio.Familias;
using SelecaoFamilia.Dominio.Familias.Pessoas;

namespace SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes.PorDependentes
{
    public class CalculaPontuacaoPorDependenteTresOuMais : ICalculaPontuacaoPorDependente
    {
        private readonly int _quantidadeDeDependentes = 3;
        private const int PONTUACAO_MAXIMA = 3;
        private const int NAO_PONTUADO = 0;
        public int CalculaPontuacao(Familia familia)
        {
            return familia.Pessoas.Where(pessoa => pessoa.TipoPessoa == TipoPessoa.Dependente).Count() >= _quantidadeDeDependentes 
                ? PONTUACAO_MAXIMA
                : NAO_PONTUADO;
        }
    }
}
