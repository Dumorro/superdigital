using System.Data;
using System.Data.SqlClient;
using ContaCorrente.Extrato.Aplicacao.Servicos;
using ContaCorrente.Extrato.Dominio.Adaptadores;
using ContaCorrente.Extrato.Dominio.Servicos;
using ContaCorrente.Extrato.Infra.ExtratoRepositorio;
using ContaCorrente.Extrato.Infra.RedisCacheAdaptador;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.Extrato.API.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDeInjecaoDeDependencia
    {
        public static void Configurar(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddScoped<IConsultaDeExtrato, ConsultaDeExtrato>();
            services.AddScoped<IExtratoDeContaCorrente, ExtratoDeContaCorrente>();
            services.AddScoped<ICacheAdaptador, RedisCacheAdaptador>();
            services.AddScoped<IExtratoRepositorio, ExtratoRepositorio>();
            services.AddScoped<IDbConnection>(d =>
                new SqlConnection(configuration.GetConnectionString("SqlConnection")));
        }
    }
}
