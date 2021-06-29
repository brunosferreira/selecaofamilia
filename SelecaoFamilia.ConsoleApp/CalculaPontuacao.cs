using SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes;
using SelecaoFamilia.Dominio.Familias;


namespace SelecaoFamilia.ConsoleApp
{
    public class CalculaPontuacao
    {
        private readonly ICalculadoraDePontuacao _calculadoraDePontuacao;

        public CalculaPontuacao(ICalculadoraDePontuacao calculadoraDePontuacao)
        {
            _calculadoraDePontuacao = calculadoraDePontuacao;
        }

        public PontuacaoDaFamiliaDTO Calcula(Familia familia)
        {
            return _calculadoraDePontuacao.Calcula(familia);
        }
    }
}
