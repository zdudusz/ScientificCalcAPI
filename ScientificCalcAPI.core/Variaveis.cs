using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcAPI.Core
{
    public static class Variaveis
    {
        public static class Geral
        {
            public static string ENV = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            ?? throw new ArgumentNullException("O ambiente não está definido");
        }
    }
}
