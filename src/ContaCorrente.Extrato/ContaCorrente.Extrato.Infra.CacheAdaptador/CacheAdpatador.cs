using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContaCorrente.Extrato.Dominio.Adaptadores;
using ContaCorrente.Extrato.Dominio.Entidades;
using EasyCaching.Core;
using Microsoft.Extensions.Logging;

namespace ContaCorrente.Extrato.Infra.CacheAdaptador
{
    public class CacheAdaptador : ICacheAdaptador
    {
        private readonly IEasyCachingProvider _cachingProvider;
        private readonly IEasyCachingProviderFactory _cachingProviderFactory;
        private readonly ILogger _logger;

        public CacheAdaptador(IEasyCachingProviderFactory cachingProviderFactory, ILogger logger)
        {
            _cachingProviderFactory = cachingProviderFactory;
            _logger = logger;
            _cachingProvider = _cachingProviderFactory.GetCachingProvider("Redis1");
        }

        public async Task<ExtratoDaContaCorrenteEmCache> Obter(string chave)
        {
            try
            {
                var cache = _cachingProvider.GetAsync<ExtratoDaContaCorrenteEmCache>(chave);
                return cache.Result.Value;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        public async Task Adicionar(string chave, ExtratoDaContaCorrenteEmCache extrato)
        {
            _cachingProvider.SetAsync($"cliente:{chave}", extrato, TimeSpan.FromMinutes(26000));
        }
    }
}
