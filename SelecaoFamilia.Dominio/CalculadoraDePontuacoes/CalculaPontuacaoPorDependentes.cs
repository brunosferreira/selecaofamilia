using SelecaoFamilia.Dominio.Familias;
using SelecaoFamilia.Dominio.Familias.Pessoas;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes
{
    public class CalculaPontuacaoPorDependentes : ICalculaPontuacao
    {
        public int CalcularPontuacao(Familia familia)
        {
            int dependentes = 0;

            foreach(var pessoa in familia.Pessoas)
            {
                if (pessoa.TipoPessoa.Equals(TipoPessoa.Dependente) && pessoa.Idade < 18)
                    dependentes++;
            }
            
            switch(dependentes)
            {
                case int n when n >= 3:
                    return 3;
                case int n when n >= 1 && n <= 2:
                    return 2;
                default:
                    return 0;
            }    
        }
    }
}
