using ContaCorrente.Extrato.Processadores.ConfiguracoesDeInicializacao;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContaCorrente.Extrato.Processadores
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    ConfiguracaoDeIoC.ConfigurarServicos(services, hostContext.Configuration);
                    services.AddHostedService<Worker>();
                });
    }
}
