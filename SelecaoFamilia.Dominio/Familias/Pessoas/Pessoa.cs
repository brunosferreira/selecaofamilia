using System;

namespace SelecaoFamilia.Dominio.Familias.Pessoas
{
    public class Pessoa
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public TipoPessoa TipoPessoa { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public decimal Renda { get; private set; }
        public StatusPessoa Status { get; private set; }
        public DateTime DataDeAtivacao { get; private set; }
        public int Idade => ObterIdade();

        public Pessoa(Guid id, string nome, TipoPessoa tipoPessoa, DateTime dataDeNascimento, decimal renda)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (dataDeNascimento > DateTime.Today)
                throw new ArgumentException("Data de Nascimento inválida");

            if (renda < 0)
                throw new ArgumentException("Renda inválida");

            Id = id;
            Nome = nome;
            TipoPessoa = tipoPessoa;
            DataDeNascimento = dataDeNascimento;
            Renda = renda;
            Status = StatusPessoa.Pendente;
        }

        public override string ToString()
        {
            return $"{this.Nome}, {this.TipoPessoa}";
        }

        public void Ativar()
        {
            Status = StatusPessoa.Ativo;
            DataDeAtivacao = DateTime.Now;
        }

        private int ObterIdade()
        {
            return DateTime.Now.Year < DataDeNascimento.Year
                ? DateTime.Now.Year - DataDeNascimento.Year
                : (DateTime.Now.Year - DataDeNascimento.Year) - 1;
        }
    }
}
