using SelecaoFamilia.Dominio.Familias.Pessoas;
using System;
using System.Collections.Generic;

namespace SelecaoFamilia.Dominio.Familias
{
    public class Familia
    {
        public Guid Id { get; private set; }
        public List<Pessoa> Pessoas { get; private set; }
        public StatusFamilia Status { get; private set; }
        public Pessoa Pretendente => Pessoas[0];

        public Familia(Guid id, Pessoa pretendente, StatusFamilia statusFamilia)
        {
            if (pretendente == null)
                throw new ArgumentException("Pretendente inválido");

            if (pretendente.TipoPessoa != TipoPessoa.Pretendente)
                throw new ArgumentException("Pessoa deve ser um pretendente");

            Id = id;
            Pessoas = new List<Pessoa>
            {
                pretendente
            };

            Status = statusFamilia;
        }

        public void AdicionarPessoa(Pessoa pessoa)
        {
            if (pessoa.TipoPessoa == TipoPessoa.Pretendente)
                throw new ArgumentException("Uma Família deve ter somente um Pretendente");

            Pessoas.Add(pessoa);
        }

        public void ValidarCadastro()
        {
            if (Id == null || Pessoas.Count == 0)
                Status = StatusFamilia.CadastroIncompleto;
        }
    }
}
