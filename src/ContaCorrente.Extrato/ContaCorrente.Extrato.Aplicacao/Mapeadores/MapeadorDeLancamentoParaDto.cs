using ContaCorrente.Extrato.Aplicacao.Dtos;
using ContaCorrente.Extrato.Dominio.Entidades;
using System;

namespace ContaCorrente.Extrato.Aplicacao.Mapeadores
{
    public class MapeadorDeLancamento
    {
        public static Lancamento MapearParaEntidade(LancamentoDto lacamentoDto)
        {
            if (lacamentoDto == null)
                return null;

            var lacamento = new Lancamento()
            {
                ContaDestino = lacamentoDto.ContaDestino,
                ContaOrigem=lacamentoDto.ContaOrigem,
                Data=lacamentoDto.Data,
                Descricao = lacamentoDto.Descricao,
                Tipo=lacamentoDto.Tipo,
                Valor=lacamentoDto.Valor
            };

            return lacamento;
        }

        public static LancamentoDto MapearParaDto(Lancamento lacamento)
        {
            if (lacamento == null)
                return null;

            var lacamentoDto = new LancamentoDto()
            {
                ContaDestino = lacamento.ContaDestino,
                ContaOrigem = lacamento.ContaOrigem,
                Data = lacamento.Data,
                Descricao = lacamento.Descricao,
                Tipo = lacamento.Tipo,
                Valor = lacamento.Valor
            };

            return lacamentoDto;
        }
    }
}
