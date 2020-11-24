using System;
using Bogus;
using SelecaoFamilia.Dominio.Familias.Pessoas;

namespace SelecaoFamilia.App._Fakers
{
    public class PessoaFaker
    {
        private static Faker faker;
        private static Guid Id;
        private static string Nome;
        private static TipoPessoa TipoPessoa;
        private static DateTime DataDeNascimento;
        private static decimal Renda;

        public static PessoaFaker Novo()
        {
            faker = new Faker("pt_BR");

            Id = Guid.NewGuid();
            Nome = faker.Person.FullName;
            TipoPessoa = faker.PickRandom<TipoPessoa>();
            DataDeNascimento = faker.Person.DateOfBirth;
            Renda = faker.Finance.Amount(0, 2500, 2);

            return new PessoaFaker();
        }

        public Pessoa Build()
        {
            return new Pessoa(Id, Nome, TipoPessoa, DataDeNascimento, Renda);
        }

        public PessoaFaker ComTipoPessoa(TipoPessoa tipoPessoa)
        {
            TipoPessoa = tipoPessoa;
            return this;
        }
    }
}
