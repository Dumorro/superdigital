using System;
using System.Threading.Tasks;
using ContaCorrente.Extrato.Dominio.Adaptadores;
using ContaCorrente.Extrato.Dominio.Entidades;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ContaCorrente.Extrato.Infra.CacheAdaptador
{
    public class CacheAdaptador : ICacheAdaptador
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _opcoesDoCache;
        public CacheAdaptador(IDistributedCache cache)
        {
            _cache = cache;
            _opcoesDoCache = new DistributedCacheEntryOptions();
            _opcoesDoCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
        }
        public async Task<ExtratoDaContaCorrenteEmCache> Obter(string chave)
        {
            try
            {
                var extratoEmCache = await _cache.GetStringAsync($"cliente:{chave}");
                if (string.IsNullOrWhiteSpace(extratoEmCache)) return null;

                var extrato = JsonConvert.DeserializeObject<ExtratoDaContaCorrenteEmCache>(extratoEmCache);

                return extrato;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

        public async Task Adicionar(string chave, ExtratoDaContaCorrenteEmCache extrato)
        {
            var extratoSerializado = JsonConvert.SerializeObject(extrato);
            await _cache.SetStringAsync($"cliente:{chave}", extratoSerializado, _opcoesDoCache);
        }
    }
}
