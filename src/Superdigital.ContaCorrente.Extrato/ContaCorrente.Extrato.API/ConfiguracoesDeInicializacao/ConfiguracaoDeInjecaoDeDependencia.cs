using System.Data;
using System.Data.SqlClient;
using ContaCorrente.Extrato.Aplicacao.Servicos;
using ContaCorrente.Extrato.Dominio.Adaptadores;
using ContaCorrente.Extrato.Dominio.Servicos;
using ContaCorrente.Extrato.Infra.CacheAdaptador;
using ContaCorrente.Extrato.Infra.ExtratoRepositorio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.Extrato.API.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDeInjecaoDeDependencia
    {
        public static void Configurar(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IConsultaDeExtrato, ConsultaDeExtrato>();
            services.AddScoped<IExtratoDeContaCorrente, ExtratoDeContaCorrente>();
            services.AddScoped<ICacheAdaptador, CacheAdaptador>();
            services.AddScoped<IExtratoRepositorio, ExtratoRepositorio>();

            services.AddSingleton(configuration);
            services.AddScoped<IDbConnection>(d =>
            {
                return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuperdigitalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            });
        }
    }
}
