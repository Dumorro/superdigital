using ContaCorrente.Extrato.Aplicacao.Dtos;
using ContaCorrente.Extrato.Dominio.Entidades;
using ContaCorrente.Extrato.Dominio.Enumeradores;
using ExpectedObjects;
using System;
using Xunit;

namespace ContaCorrente.Extrato.TestesDeUnidade.Aplicacao
{
    public class MapeadorDeLancamentoTestes
    {
        [Fact]
        public void DeveMapearLancamento()
        {
            var dataLacamento = DateTime.Now;
            var lacamentoDto = new LancamentoDto
            {
                ContaOrigem = "001234",
                ContaDestino = "002256",
                Data = dataLacamento,
                Descricao = "Tranferência entre contas",
                Tipo = TipoDeLancamento.TRANSFERENCIA
            };
            var lacamentoEsperado = new Lancamento
            {
                ContaOrigem = "001234",
                ContaDestino = "002256",
                Data = dataLacamento,
                Descricao = "Tranferência entre contas",
                Tipo = TipoDeLancamento.TRANSFERENCIA
            }.ToExpectedObject();
            var lacamentoObtido = Extrato.Aplicacao.Mapeadores.MapeadorDeLancamento.MapearParaEntidade(lacamentoDto);

            lacamentoEsperado.ShouldMatch(lacamentoObtido);
        }

        [Fact]
        public void NaoDeveMapearLacamentoQuandoDTOForNulo()
        {
            LancamentoDto lacamentoDto = null;
            var lacamentoObtido = Extrato.Aplicacao.Mapeadores.MapeadorDeLancamento.MapearParaEntidade(lacamentoDto);

            Assert.Null(lacamentoObtido);
        }
    }
}
