using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.Extrato.API.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDoMVC
    {
        public static void Configurar(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}
