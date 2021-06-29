using Microsoft.Extensions.DependencyInjection;
using SelecaoFamilia.Aplicacao.CalculadoraDePontuacoes;

namespace SelecaoFamilia.Infra.IoC
{
    public static class StartupIoC
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(ICalculadoraDePontuacao), typeof(CalculadoraDePontuacao));
            services.AddScoped(typeof(ICalculaPontuacao), typeof(CalculaPontuacaoPorDependentes));
            services.AddScoped(typeof(ICalculaPontuacao), typeof(CalculaPontuacaoPorIdade));
            services.AddScoped(typeof(ICalculaPontuacao), typeof(CalculaPontuacaoPorRenda));

            services.AddScoped<CalculadoraDePontuacao>();
        }
    }
}
