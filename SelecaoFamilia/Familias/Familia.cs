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
        public int Pontuacao { get; private set; }
        public int CriteriosAtendidos { get; private set; }

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
            Pontuacao = 0;
            CriteriosAtendidos = 0;
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
            //inserir os demais casos de validação JaSelecionadaEmOutroCadastro e JaPossuiCasa
        }

        public void CalcularPontuacao()
        {
            CalculadoraDePontuacao cpIdade = new CalculadoraDePontuacao(new CalculaPontuacaoIdade());
            CalculadoraDePontuacao cpRenda = new CalculadoraDePontuacao(new CalculaPontuacaoRenda());
            CalculadoraDePontuacao cpDependentes = new CalculadoraDePontuacao(new CalculaPontuacaoDependentes());

            int ptIdade = cpIdade.Calcular(this);
            int ptRenda = cpRenda.Calcular(this);
            int ptDependentes = cpDependentes.Calcular(this);

            if(ptIdade > 0)
                CriteriosAtendidos++;

            if (ptRenda > 0)
                CriteriosAtendidos++;

            if (ptDependentes > 0)
                CriteriosAtendidos++;

            Pontuacao = ptIdade + ptRenda + ptDependentes;
        }
    }
}
