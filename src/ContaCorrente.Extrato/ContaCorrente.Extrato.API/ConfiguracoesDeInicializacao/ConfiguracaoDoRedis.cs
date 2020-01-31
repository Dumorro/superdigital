using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.Extrato.API.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDoRedis
    {
        public static void Configurar(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("RedisConnection");
                options.InstanceName = "ExtratoCC:";
            });
        }
    }
}
