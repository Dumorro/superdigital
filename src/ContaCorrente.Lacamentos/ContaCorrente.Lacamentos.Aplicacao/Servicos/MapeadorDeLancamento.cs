
using ContaCorrente.Lacamentos.Aplicacao.Dtos;
using ContaCorrente.Lacamentos.Dominio.Entidade;

namespace ContaCorrente.Lacamentos.Aplicacao.Servicos
{
    public class MapeadorDeLancamento
    {
        public static Lancamento Mapear(LancamentoDto lancamentoDto)
        {
            var descricao = lancamentoDto.Tipo == 1 ? "TRANSFERENCIA ENTRE CONTAS" : "TRANSFERENCIA DOC/TED";
            return new Lancamento(
                lancamentoDto.IdCliente,
                lancamentoDto.ContaOrigem,
                lancamentoDto.ContaDestino,
                lancamentoDto.Tipo,
                descricao,
                lancamentoDto.Valor);
        }
    }
}
