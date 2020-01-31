using EasyCaching.Core;
using EasyCaching.Core.Configurations;
using EasyCaching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.Extrato.API.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDoRedis
    {
        public static void Configurar(IServiceCollection services, IConfiguration configuration)
        {
            var endpoint = configuration.GetSection("RedisCfg")["Endpoint"];
            var port = int.Parse(configuration.GetSection("RedisCfg")["Port"]);
            var password = configuration.GetSection("RedisCfg")["Pws"];
            services.AddEasyCaching(cfg =>
            {
                cfg.UseRedis(r =>
                {
                    r.DBConfig.IsSsl = true;
                    r.DBConfig.Endpoints.Add(new ServerEndPoint() {Host = endpoint, Port = port});
                    r.DBConfig.AllowAdmin = true;
                    r.DBConfig.Password = password;
                }, "Redis1");
            });
        }
    }
}
