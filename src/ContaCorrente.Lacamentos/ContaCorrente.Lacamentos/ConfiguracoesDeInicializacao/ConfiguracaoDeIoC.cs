using ContaCorrente.Lacamentos.Aplicacao.Servicos;
using ContaCorrente.Lacamentos.Dominio.Entidades;
using MassTransit;
using MassTransit.Azure.ServiceBus.Core;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.Lacamentos.Api.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDeIoC
    {
        public static void ConfigurarServicos(IServiceCollection services, IConfiguration configuration)
        {
            var conexaoServiceBus = configuration.GetValue<string>("ServiceBusConfig:ConnectionString");
            var fila = configuration.GetValue<string>("ServiceBusConfig:Queue");
            services.AddSingleton(new DadosDeConfiguracaoDoServicoDeMensageria(conexaoServiceBus, fila));
            services.AddSingleton(configuration);
            var azureServiceBus = Bus.Factory.CreateUsingAzureServiceBus(busFactoryConfig =>
            {
                var host = busFactoryConfig.Host(conexaoServiceBus, hostConfig =>
                {
                    hostConfig.TransportType = TransportType.AmqpWebSockets;
                });

            });
            services.AddMassTransit(config =>
            {
                config.AddBus(provider => azureServiceBus);
            });
            services.AddSingleton<ISendEndpointProvider>(azureServiceBus);
            services.AddSingleton<IBus>(azureServiceBus);
            services.AddScoped<IEnvioDeLacamentoEmContacorrente, EnvioDeLacamentoEmContacorrente>();
        }
    }
}
