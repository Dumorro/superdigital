using ContaCorrente.Extrato.Dominio.Adaptadores;
using ContaCorrente.Extrato.Dominio.Entidades;
using ContaCorrente.Extrato.Dominio.Servicos;
using ContaCorrente.Extrato.TestesDeUnidade.Dominio;
using ExpectedObjects;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ContaCorrente.Extrato.TestesDeUnidade.ObjetosAuxilares
{
    public class ExtratoTestes
    {
        private readonly Guid _idCliente = Guid.NewGuid();
        private readonly Mock<IExtratoRepositorio> _repositorioDeLacamentos;
        private readonly Mock<ICacheAdaptador> _servicoDeCache;
        public ExtratoTestes()
        {
            _repositorioDeLacamentos = new Mock<IExtratoRepositorio>();
            _servicoDeCache = new Mock<ICacheAdaptador>();
        }

        [Fact]
        public void DeveObterExtratoDoCache()
        {
            _servicoDeCache.Setup(c => c.Obter(_idCliente.ToString()))
                .Returns(Task.FromResult(new ExtratoDaContaCorrenteEmCache
                {
                    IdCliente = _idCliente,
                    Lancamentos = LacamentosParaTeste.Dados
                }));
            var _consultorDeExtrato = new ExtratoDeContaCorrente(_repositorioDeLacamentos.Object, _servicoDeCache.Object);
            var extratoEsperado = LacamentosParaTeste.Dados;

            var extratoObtido = _consultorDeExtrato.ObterLacamentos(_idCliente);

            extratoEsperado.ToExpectedObject().Matches(extratoObtido);
        }

        [Fact]
        public void DeveObterExtratoDoRepositorioQuandoOCacheNaoEstiverAquecido()
        {
            _repositorioDeLacamentos.Setup(r => r.ListarLancamentos(_idCliente))
                .Returns(Task.FromResult(LacamentosParaTeste.Dados));
            var _consultorDeExtrato = new ExtratoDeContaCorrente(_repositorioDeLacamentos.Object, _servicoDeCache.Object);
            var extratoEsperado = LacamentosParaTeste.Dados;

            var extratoObtido = _consultorDeExtrato.ObterLacamentos(_idCliente);

            extratoEsperado.ToExpectedObject().Matches(extratoObtido);
        }
    }
}
