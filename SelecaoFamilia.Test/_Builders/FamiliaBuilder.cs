using SelecaoFamilia.Dominio.Familias;
using SelecaoFamilia.Dominio.Familias.Pessoas;
using System;

namespace SelecaoFamilia.Test._Builders
{
    public class FamiliaBuilder
    {
        private Guid Id = Guid.NewGuid();
        private Pessoa Pessoa = PessoaBuilder.Novo().Build();
        private StatusFamilia StatusFamilia = StatusFamilia.CadastroValido;

        public static FamiliaBuilder Novo()
        {
            return new FamiliaBuilder();
        }

        public Familia Build()
        {
            return new Familia(Id, Pessoa, StatusFamilia);
        }

        public FamiliaBuilder ComStatus(StatusFamilia statusFamilia)
        {
            StatusFamilia = statusFamilia;
            return this;
        }

        public FamiliaBuilder ComPessoa(Pessoa pessoa)
        {
            Pessoa = pessoa;
            return this;
        }
    }
}
