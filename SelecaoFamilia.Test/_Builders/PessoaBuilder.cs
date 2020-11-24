using Bogus;
using SelecaoFamilia.Dominio.Familias.Pessoas;
using System;

namespace SelecaoFamilia.Test._Builders
{
    public class PessoaBuilder
    {
        private static Faker faker = new Faker("pt_BR");
        
        private Guid id = Guid.NewGuid();
        private string nome = faker.Person.FullName;
        private TipoPessoa tipoPessoa = TipoPessoa.Pretendente;
        private DateTime dataDeNascimento = faker.Person.DateOfBirth;
        private decimal renda = faker.Finance.Amount(0, 3500, 2);

        public static PessoaBuilder Novo()
        {
            return new PessoaBuilder();
        }

        public Pessoa Build()
        {
            return new Pessoa(id, nome, tipoPessoa, dataDeNascimento, renda);
        }

        public PessoaBuilder ComTipoPessoa(TipoPessoa tipoPessoa)
        {
            this.tipoPessoa = tipoPessoa;
            return this;
        }

        public PessoaBuilder ComRenda(decimal renda)
        {
            this.renda = renda;
            return this;
        }

        public PessoaBuilder ComNome(string nome)
        {
            this.nome = nome;
            return this;
        }

        public PessoaBuilder ComDataDeNascimento(DateTime dataDeNascimento)
        {
            this.dataDeNascimento = dataDeNascimento;
            return this;
        }

        public PessoaBuilder ComMenorDeIdade()
        {
            DateTime dataDezoitoAnos = DateTime.Now.AddYears(-17);
            this.dataDeNascimento = faker.Date.Between(dataDezoitoAnos, DateTime.Today);
            return this;
        }
    }
}
