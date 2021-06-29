using SelecaoFamilia.Dominio.Familias;
using SelecaoFamilia.Dominio.Familias.Pessoas;
using System;

namespace SelecaoFamilia.ConsoleApp
{
    public static class CriaFamilia
    {
        public static Familia Criar()
        {
            var pretendente = new Pessoa("Bruno Ferreira", TipoPessoa.Pretendente, new DateTime(1982, 12, 31), 1500);
            return new Familia(pretendente, StatusFamilia.CadastroValido);
        }
    }
}
