using SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes;
using SelecaoFamilia.Dominio.Familias;
using SelecaoFamilia.Infra.IoC;
using System;

namespace SelecaoFamilia.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var familia = CriaFamilia.Criar();
            CalculaPontuacao calculaPontuacao = new CalculaPontuacao(new CalculadoraDePontuacao());
            var pontuacaoFamiliaDTO = calculaPontuacao.Calcula(familia);

            Console.WriteLine(String.Format("familia: {0}, pontuação: {1}, criterios atendidos: {2}",
                pontuacaoFamiliaDTO.Id,
                pontuacaoFamiliaDTO.Pontuacao,
                pontuacaoFamiliaDTO.CriteriosAtendidos));
        }
    }
}
