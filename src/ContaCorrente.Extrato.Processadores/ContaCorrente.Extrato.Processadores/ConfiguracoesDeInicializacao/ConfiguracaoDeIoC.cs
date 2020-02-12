using ContaCorrente.Extrato.Processadores.Dominio.Adaptadores;
using ContaCorrente.Extrato.Processadores.Dominio.Models;
using ContaCorrente.Extrato.Processadores.Infra.ExtratoRepositorio;
using ContaCorrente.Extrato.Processadores.Infra.Mensageria;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace ContaCorrente.Extrato.Processadores.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDeIoC
    {
        public static void ConfigurarServicos(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(typeof(DadosDeConfigacaoDaMensageria), 
                new DadosDeConfigacaoDaMensageria(configuration.GetValue<string>("ServiceBusConfig:ConnectionString"),
                                                  configuration.GetValue<string>("ServiceBusConfig:QueueName")));
            services.AddTransient<IDbConnection>(db => new SqlConnection(configuration.GetConnectionString("SqlConnection")));
            services.AddTransient<IServiceBusAdaptador, ServiceBusAdaptador>();
            services.AddTransient<IExtratoRepositorio, ExtratoRepositorio>();
        }
    }
}
