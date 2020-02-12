using ContaCorrente.Lacamentos.Aplicacao.Servicos;
using ContaCorrente.Lacamentos.Dominio.Adaptadores;
using ContaCorrente.Lacamentos.Dominio.Entidades;
using ContaCorrente.Lacamentos.Infra.Mensageria;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.Lacamentos.Api.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDeInjecaoDeDependencia
    {
        public static void Configurar(IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddSingleton(configuration); 

             var conexaoServiceBus = configuration.GetValue<string>("ServiceBusConfig:ConnectionString");
            var nomeDaFila  = configuration.GetValue<string>("ServiceBusConfig:QueueName");
            services.AddSingleton(new DadosDeConfiguracaoDoServicoDeMensageria(conexaoServiceBus, nomeDaFila));
            services.AddScoped<IEnvioDeLacamentoEmContacorrente, EnvioDeLacamentoEmContacorrente>();
            services.AddScoped<IMensageriaAdaptador, MensageriaAdaptador>();
        }
    }
}
