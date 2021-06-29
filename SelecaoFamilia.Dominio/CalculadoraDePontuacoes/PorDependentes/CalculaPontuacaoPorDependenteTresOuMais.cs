using System.Linq;
using SelecaoFamilia.Dominio.Familias;
using SelecaoFamilia.Dominio.Familias.Pessoas;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes.PorDependentes
{
    public class CalculaPontuacaoPorDependenteTresOuMais : ICalculaPontuacaoPorDependente
    {
        private readonly int _quantidadeDeDependentes = 3;
        public int CalculaPontuacao(Familia familia)
        {
            return familia.Pessoas.Where(pessoa => pessoa.TipoPessoa == TipoPessoa.Dependente).Count() >= _quantidadeDeDependentes ? 3 : 0;
        }
    }
}
