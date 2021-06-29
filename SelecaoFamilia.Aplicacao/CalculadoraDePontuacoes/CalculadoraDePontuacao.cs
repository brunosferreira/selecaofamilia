using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes
{
    public class CalculadoraDePontuacao : ICalculadoraDePontuacao
    {
        private readonly ICalculaPontuacao _calculaPontuacaoPorIdade;
        private readonly ICalculaPontuacao _calculaPontuacaoPorRenda;
        private readonly ICalculaPontuacao _calculaPontuacaoPorDependentes;

        public CalculadoraDePontuacao()
        {
            _calculaPontuacaoPorIdade = new CalculaPontuacaoPorIdade();
            _calculaPontuacaoPorRenda = new CalculaPontuacaoPorRenda();
            _calculaPontuacaoPorDependentes = new CalculaPontuacaoPorDependentes();
        }

        public PontuacaoDaFamiliaDTO Calcula(Familia familia)
        {
            PontuacaoDaFamiliaDTO pontuacaoDaFamiliaDTO = new PontuacaoDaFamiliaDTO();
            pontuacaoDaFamiliaDTO.Id = familia.Id;
            
            var pontuacaoPorIdade = CalcularPorIdade(familia);
            var pontuacaoPorRenda = CalcularPorRenda(familia);
            var pontuacaoPorDependentes = CalcularPorDependente(familia);

            pontuacaoDaFamiliaDTO.CriteriosAtendidos = 0;

            if (pontuacaoPorIdade > 0)
                pontuacaoDaFamiliaDTO.CriteriosAtendidos++;

            if (pontuacaoPorRenda > 0)
                pontuacaoDaFamiliaDTO.CriteriosAtendidos++;

            if (pontuacaoPorDependentes > 0)
                pontuacaoDaFamiliaDTO.CriteriosAtendidos++;

            pontuacaoDaFamiliaDTO.Pontuacao = pontuacaoPorIdade + pontuacaoPorRenda + pontuacaoPorDependentes;

            return pontuacaoDaFamiliaDTO;
        }

        private int CalcularPorIdade(Familia familia)
        {
            return _calculaPontuacaoPorIdade.CalcularPontuacao(familia);
        }

        private int CalcularPorRenda(Familia familia)
        {
            return _calculaPontuacaoPorRenda.CalcularPontuacao(familia);
        }

        private int CalcularPorDependente(Familia familia)
        {
            return _calculaPontuacaoPorDependentes.CalcularPontuacao(familia);
        }
    }
}
