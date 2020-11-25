using System;

namespace SelecaoFamilia.Dominio.Familias.Contemplados
{
    public class Contemplado
    {
        public Guid Id { get; private set; }
        public Familia Familia { get; private set; }
        public DateTime Data { get; private set; }

        public Contemplado(Familia familia)
        {
            if (familia == null)
                throw new ArgumentException("Família inválida");

            if (familia.Status != StatusFamilia.CadastroValido)
                throw new ArgumentException("Situação da família é inválida");
            Id = Guid.NewGuid();
            Familia = familia;
            Data = DateTime.Today;
        }
    }
}
