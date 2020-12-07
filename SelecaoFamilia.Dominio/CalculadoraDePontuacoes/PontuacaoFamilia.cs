using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Dominio.CalculadoraDePontuacoes
{
    public class PontuacaoFamilia
    {
        private readonly ICalculaPontuacao CalculaPontuacaoPorIdade;
        private readonly ICalculaPontuacao CalculaPontuacaoPorRenda;
        private readonly ICalculaPontuacao CalculaPontuacaoPorDependentes;

        public Familia Familia {get; private set;}
        public int Pontuacao { get; private set; }
        public int CriteriosAtendidos { get; private set; }

        public PontuacaoFamilia(Familia familia)
        {
            CalculaPontuacaoPorIdade = new CalculaPontuacaoPorIdade();
            CalculaPontuacaoPorRenda = new CalculaPontuacaoPorRenda();
            CalculaPontuacaoPorDependentes = new CalculaPontuacaoPorDependentes();
            Familia = familia;
            Calcular();
        }

        public void Calcular()
        {
            int pontuacaoPorIdade = CalcularPorIdade();
            int pontuacaoPorRenda = CalcularPorRenda();
            int pontuacaoPorDependentes = CalcularPorDependente();

            CriteriosAtendidos = 0;

            if (pontuacaoPorIdade > 0)
                CriteriosAtendidos++;

            if (pontuacaoPorRenda > 0)
                CriteriosAtendidos++;

            if (pontuacaoPorDependentes > 0)
                CriteriosAtendidos++;

            Pontuacao = pontuacaoPorIdade + pontuacaoPorRenda + pontuacaoPorDependentes;
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
