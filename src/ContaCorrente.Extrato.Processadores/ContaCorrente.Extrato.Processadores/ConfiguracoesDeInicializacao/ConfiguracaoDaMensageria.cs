using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.Extrato.Processadores.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDaMensageria
    {
        public static void Configuracao(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(typeof(DadosDeConfigacaoDaMensageria), 
                new DadosDeConfigacaoDaMensageria(configuration.GetConnectionString("RedisConnection"),
                                                  configuration.GetValue<string>("SBQueueName")));
        }
    }
}
