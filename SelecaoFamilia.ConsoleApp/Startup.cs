using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SelecaoFamilia.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelecaoFamilia.ConsoleApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            StartupIoC.ConfigureServices(services);
        }
    }
}
