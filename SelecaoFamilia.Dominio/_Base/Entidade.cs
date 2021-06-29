using System;

namespace SelecaoFamilia.Dominio._Base
{
    public abstract class Entidade
    {
        public virtual Guid Id { get; protected set; }
    }
}
