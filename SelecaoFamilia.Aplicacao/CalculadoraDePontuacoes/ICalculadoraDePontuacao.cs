using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes
{
    public interface ICalculadoraDePontuacao
    {
        public PontuacaoDaFamiliaDTO Calcula(Familia familia);
    }
}