using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes
{
    public class CalculadoraDeCriteriosDaFamilia
    {
        private readonly ICalculaPontuacaoPorIdade _calculaPontuacaoPorIdade;
        private readonly ICalculaPontuacaoPorIdade _calculaPontuacaoPorRenda;
        private readonly ICalculaPontuacaoPorIdade _calculaPontuacaoPorDependentes;
        private readonly PontuacaoDaFamiliaDTO _pontuacaoDaFamiliaDTO;

        public Familia Familia {get; private set; }

        public CalculadoraDeCriteriosDaFamilia(Familia familia)
        {
            _calculaPontuacaoPorIdade = new CalculaPontuacaoPorIdade();
            _calculaPontuacaoPorRenda = new CalculaPontuacaoPorRenda();
            _calculaPontuacaoPorDependentes = new CalculaPontuacaoPorDependentes();
            _pontuacaoDaFamiliaDTO = new PontuacaoDaFamiliaDTO();
            Familia = familia;
        }

        public PontuacaoDaFamiliaDTO Calcular()
        {
            var pontuacaoPorIdade = CalcularPorIdade();
            var pontuacaoPorRenda = CalcularPorRenda();
            var pontuacaoPorDependentes = CalcularPorDependente();

            _pontuacaoDaFamiliaDTO.CriteriosAtendidos = 0;

            if (pontuacaoPorIdade > 0)
                _pontuacaoDaFamiliaDTO.CriteriosAtendidos++;

            if (pontuacaoPorRenda > 0)
                _pontuacaoDaFamiliaDTO.CriteriosAtendidos++;

            if (pontuacaoPorDependentes > 0)
                _pontuacaoDaFamiliaDTO.CriteriosAtendidos++;

            _pontuacaoDaFamiliaDTO.Pontuacao = pontuacaoPorIdade + pontuacaoPorRenda + pontuacaoPorDependentes;

            return _pontuacaoDaFamiliaDTO;
        }

        private int CalcularPorIdade()
        {
            return _calculaPontuacaoPorIdade.CalcularPontuacao(Familia);
        }

        private int CalcularPorRenda()
        {
            return _calculaPontuacaoPorRenda.CalcularPontuacao(Familia);
        }

        private int CalcularPorDependente()
        {
            return _calculaPontuacaoPorDependentes.CalcularPontuacao(Familia);
        }
    }
}
