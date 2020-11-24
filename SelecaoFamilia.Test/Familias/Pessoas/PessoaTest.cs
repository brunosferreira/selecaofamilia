using System;
using ExpectedObjects;
using Xunit;
using SelecaoFamilia.Dominio.Familias.Pessoas;
using SelecaoFamilia.Test._Builders;

namespace SelecaoFamilia.Test.Familias.Pessoas
{
    public class PessoaTest
    {
        [Fact]
        public void DeveCriarPessoa()
        {
            var pessoaEsperada = PessoaBuilder.Novo().Build();

            var pessoa = new Pessoa(pessoaEsperada.Id, pessoaEsperada.Nome, pessoaEsperada.TipoPessoa, pessoaEsperada.DataDeNascimento, pessoaEsperada.Renda);

            pessoaEsperada.ToExpectedObject().ShouldMatch(pessoa);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDevePessoaTerNomeInvalido(string nome)
        {
            Assert.Throws<ArgumentException>(() => PessoaBuilder.Novo().ComNome(nome).Build());
        }

        [Fact]
        public void NaoDevePessoaTerDataDeNascimentoInvalida()
        {
            Assert.Throws<ArgumentException>(() => PessoaBuilder.Novo().ComDataDeNascimento(DateTime.Today.AddDays(1)).Build());
        }

        [Fact]
        public void NaoDevePessoaTerRendaNegativa()
        {
            Assert.Throws<ArgumentException>(() => PessoaBuilder.Novo().ComRenda((decimal)-50.00).Build());
        }

        [Fact]
        public void DeveCriarPessoaComStatusPendente()
        {
            var statusPessoaEsperado = StatusPessoa.Pendente;
            
            var pessoa = PessoaBuilder.Novo().Build();

            Assert.Equal(statusPessoaEsperado, pessoa.Status);
        }

        [Fact]
        public void DevePessoaSerAtivada()
        {
            var statusPessoaEsperado = StatusPessoa.Ativo;
            var pessoa = PessoaBuilder.Novo().Build();
            
            pessoa.Ativar();

            Assert.Equal(statusPessoaEsperado, pessoa.Status);
        }
    }
}
