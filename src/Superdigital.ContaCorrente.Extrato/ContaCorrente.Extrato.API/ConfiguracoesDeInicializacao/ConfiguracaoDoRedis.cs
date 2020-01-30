using EasyCaching.Core;
using EasyCaching.Core.Configurations;
using EasyCaching.Redis;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.Extrato.API.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDoRedis
    {
        public static void Configurar(IServiceCollection services)
        {
            var endpoint = "localhost";
            var port = 6379;
            services.AddEasyCaching(cfg =>
            {
                cfg.UseRedis(r =>
                {
                    r.DBConfig.Endpoints.Add(new ServerEndPoint() {Host = endpoint, Port = port});
                    r.DBConfig.AllowAdmin = true;
                }, "Redis1");
            });
        }
    }
}
