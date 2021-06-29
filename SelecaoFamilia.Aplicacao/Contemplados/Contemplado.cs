using System;
using SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes;
using SelecaoFamilia.Dominio.Familias;

namespace SelecaoFamilia.Aplicacao.Contemplados
{
    public class Contemplado
    {
        public Guid Id { get; private set; }
        public DateTime Data { get; private set; }
        public PontuacaoDaFamiliaDTO PontuacaoDaFamiliaDTO { get; private set; }
        public Familia Familia { get; private set; }
        private readonly ICalculadoraDePontuacao _calculadoraDePontuacao;

        public Contemplado(ICalculadoraDePontuacao calculadoraDePontuacao)
        {
            _calculadoraDePontuacao = calculadoraDePontuacao;
            
            Id = Guid.NewGuid();
            Data = DateTime.Today;
        }

        public void AdicionaFamilia(Familia familia)
        {
            if (familia == null)
                throw new ArgumentException("Família inválida");

            if (familia.Status != StatusFamilia.CadastroValido)
                throw new ArgumentException("Situação da família é inválida");

            Familia = familia;
        }
    }
}
