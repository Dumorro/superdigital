using ContaCorrente.Extrato.Aplicacao.Dtos;
using ContaCorrente.Extrato.TestesDeUnidade.Dominio;
using ExpectedObjects;
using System;
using System.Linq;
using System.Threading.Tasks;
using ContaCorrente.Extrato.Aplicacao.Mapeadores;
using ContaCorrente.Extrato.Aplicacao.Servicos;
using ContaCorrente.Extrato.Dominio.Servicos;
using Moq;
using Xunit;

namespace ContaCorrente.Extrato.TestesDeUnidade.Aplicacao
{
    public class ConsultaDeExtratoTestes
    {
        [Fact]
        public void DeveRetornarExtratoDeContaCorrenteDoCliente()
        {
            var idCliente = Guid.NewGuid();
            var extratoContaCorrente = new Mock<IExtratoDeContaCorrente>();
            extratoContaCorrente.Setup(extrato => extrato.ObterLacamentos(idCliente))
                .Returns(Task.FromResult(LacamentosParaTeste.Dados));
            var extratoEsperado = new ExtratoDto()
            {
                IdCliente = idCliente,
                Lancamentos = LacamentosParaTeste.Dados.Select(MapeadorDeLancamento.MapearParaDto)
            }.ToExpectedObject();

            var consultaDeExtrato = new ConsultaDeExtrato(extratoContaCorrente.Object);
            var extratoObtido = consultaDeExtrato.Obter(idCliente);

            extratoEsperado.Matches(extratoObtido);
        }
    }
}
