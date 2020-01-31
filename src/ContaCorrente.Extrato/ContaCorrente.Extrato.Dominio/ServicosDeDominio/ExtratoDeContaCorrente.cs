using ContaCorrente.Extrato.Dominio.Adaptadores;
using ContaCorrente.Extrato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContaCorrente.Extrato.Dominio.Servicos
{
    public class ExtratoDeContaCorrente : IExtratoDeContaCorrente
    {
        private readonly IExtratoRepositorio _repositorio;
        private readonly ICacheAdaptador _servidoDeCache;

        public ExtratoDeContaCorrente(IExtratoRepositorio repositorio, ICacheAdaptador servicoDeCache)
        {
            _repositorio = repositorio;
            _servidoDeCache = servicoDeCache;
        }
        public async Task<IEnumerable<Lancamento>> ObterLacamentos(Guid idCliente)
        {
            var extratoEmCache = await _servidoDeCache.Obter(idCliente.ToString());
            IEnumerable<Lancamento> lancamentos = extratoEmCache?.Lancamentos;
            if (extratoEmCache == null)
            {
                lancamentos = await _repositorio.ListarLancamentos(idCliente);
                await _servidoDeCache.Adicionar(idCliente.ToString(), new ExtratoDaContaCorrenteEmCache()
                {
                    IdCliente= idCliente,
                    Lancamentos = lancamentos
                });
            }
            return lancamentos;
        }
    }
}
