using System;
using System.Threading.Tasks;
using ContaCorrente.Extrato.Dominio.Adaptadores;
using ContaCorrente.Extrato.Dominio.Entidades;

namespace ContaCorrente.Extrato.Infra.CacheAdaptador
{
    public class CacheAdaptador : ICacheAdaptador
    {
        public async Task<ExtratoDaContaCorrenteEmCache> Obter(string chave)
        {
            try
            {
                return null;
                // var cache = _cachingProvider.GetAsync<ExtratoDaContaCorrenteEmCache>(chave);
                //  return cache.Result.Value;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

        public async Task Adicionar(string chave, ExtratoDaContaCorrenteEmCache extrato)
        {
            //_cachingProvider.SetAsync($"cliente:{chave}", extrato, TimeSpan.FromMinutes(26000));
        }
    }
}
