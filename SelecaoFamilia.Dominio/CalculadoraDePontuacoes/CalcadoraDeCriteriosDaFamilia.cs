using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes
{
    public class CalcadoraDeCriteriosDaFamilia
    {
        private readonly ICalculaPontuacao CalculaPontuacaoPorIdade;
        private readonly ICalculaPontuacao CalculaPontuacaoPorRenda;
        private readonly ICalculaPontuacao CalculaPontuacaoPorDependentes;
        private readonly PontuacaoDaFamiliaDTO PontuacaoDaFamiliaDTO;

        public Familia Familia {get; private set;}

        public CalcadoraDeCriteriosDaFamilia(Familia familia)
        {
            CalculaPontuacaoPorIdade = new CalculaPontuacaoPorIdade();
            CalculaPontuacaoPorRenda = new CalculaPontuacaoPorRenda();
            CalculaPontuacaoPorDependentes = new CalculaPontuacaoPorDependentes();
            PontuacaoDaFamiliaDTO = new PontuacaoDaFamiliaDTO();
            Familia = familia;
        }

        public PontuacaoDaFamiliaDTO Calcular()
        {
            int pontuacaoPorIdade = CalcularPorIdade();
            int pontuacaoPorRenda = CalcularPorRenda();
            int pontuacaoPorDependentes = CalcularPorDependente();

            PontuacaoDaFamiliaDTO.CriteriosAtendidos = 0;

            if (pontuacaoPorIdade > 0)
                PontuacaoDaFamiliaDTO.CriteriosAtendidos++;

            if (pontuacaoPorRenda > 0)
                PontuacaoDaFamiliaDTO.CriteriosAtendidos++;

            if (pontuacaoPorDependentes > 0)
                PontuacaoDaFamiliaDTO.CriteriosAtendidos++;

            PontuacaoDaFamiliaDTO.Pontuacao = pontuacaoPorIdade + pontuacaoPorRenda + pontuacaoPorDependentes;

            return PontuacaoDaFamiliaDTO;
        }

        public int CalcularPorIdade()
        {
            return CalculaPontuacaoPorIdade.CalcularPontuacao(Familia);
        }

        public int CalcularPorRenda()
        {
            return CalculaPontuacaoPorRenda.CalcularPontuacao(Familia);
        }

        public int CalcularPorDependente()
        {
            return CalculaPontuacaoPorDependentes.CalcularPontuacao(Familia);
        }
    }
}
