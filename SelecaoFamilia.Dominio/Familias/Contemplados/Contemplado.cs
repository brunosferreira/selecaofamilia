using System;
using SelecaoFamilia.Dominio.CalculadoraDePontuacoes;

namespace SelecaoFamilia.Dominio.Familias.Contemplados
{
    public class Contemplado
    {
        public Guid Id { get; private set; }
        public DateTime Data { get; private set; }
        public PontuacaoFamilia PontuacaoFamilia { get; private set; }

        public Contemplado(Familia familia)
        {
            if (familia == null)
                throw new ArgumentException("Família inválida");

            if (familia.Status != StatusFamilia.CadastroValido)
                throw new ArgumentException("Situação da família é inválida");

            Id = Guid.NewGuid();
            Data = DateTime.Today;

            PontuacaoFamilia = new PontuacaoFamilia(familia);
        }
    }
}
