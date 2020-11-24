using SelecaoFamilia.Dominio.Familias;
using SelecaoFamilia.Dominio.Familias.Pessoas;
using SelecaoFamilia.Dominio.Familias.Contemplados;
using SelecaoFamilia.App._Fakers;
using System;
using System.Collections.Generic;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Contemplados = new List<Contemplado>();

            Contemplados = GerarDadosFake();
            Contemplados.Sort((x, y) => y.Familia.Pontuacao.CompareTo(x.Familia.Pontuacao));

            foreach (var contemplado in Contemplados)
            {
                Console.WriteLine($"familia: {contemplado.Familia.Id}, pontuação: {contemplado.Familia.Pontuacao}");
                foreach (var pessoa in contemplado.Familia.Pessoas)
                {
                    Console.WriteLine($"pessoa: {pessoa.Nome}");
                }
                Console.WriteLine();
            }
        }

        private static List<Contemplado> GerarDadosFake()
        {
            var Contemplados = new List<Contemplado>();
            var random = new Random();

            for (var i = 1; i <= 200; i++)
            {
                var familia = new Familia(Guid.NewGuid(), PessoaFaker.Novo().ComTipoPessoa(TipoPessoa.Pretendente).Build(), StatusFamilia.CadastroValido);
                familia.AdicionarPessoa(PessoaFaker.Novo().ComTipoPessoa(TipoPessoa.Conjuge).Build());

                var quantidadeDeDependentes = random.Next(0, 3);
                for (var j = 1; j <= quantidadeDeDependentes; j++)
                {
                    familia.AdicionarPessoa(PessoaFaker.Novo().ComTipoPessoa(TipoPessoa.Dependente).Build());
                }

                familia.CalcularPontuacao();

                Contemplados.Add(new Contemplado(familia));
            }

            return Contemplados;
        }
    }
}
