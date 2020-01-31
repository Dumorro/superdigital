using ContaCorrente.Extrato.Dominio.Entidades;
using ContaCorrente.Extrato.Dominio.Enumeradores;
using System;
using System.Collections.Generic;

namespace ContaCorrente.Extrato.TestesDeUnidade.Dominio
{
    public class LacamentosParaTeste
    {
        public static IEnumerable<Lancamento> Dados
        {
            get
            {
                var idCliente = Guid.NewGuid();
                const string contaCliente = "0123456";
                yield return new Lancamento
                {
                    IdCliente = idCliente,
                    ContaOrigem = contaCliente,
                    ContaDestino = "0123192",
                    Data = DateTime.Now.AddDays(-10),
                    Tipo = TipoDeLancamento.TED,
                    Descricao = "TED para conta corrente",
                    Valor = 1003.93
                };
                yield return new Lancamento
                {
                    IdCliente = idCliente,
                    ContaOrigem = contaCliente,
                    ContaDestino = "013476",
                    Data = DateTime.Now.AddDays(-21),
                    Tipo = TipoDeLancamento.TED,
                    Descricao = "TED para conta corrente",
                    Valor = 6000.40
                };
                yield return new Lancamento
                {
                    IdCliente = idCliente,
                    ContaOrigem = "4351566",
                    ContaDestino = contaCliente,
                    Data = DateTime.Now.AddDays(-10),
                    Tipo = TipoDeLancamento.TRANSFERENCIA,
                    Descricao = "Transferência para conta corrente",
                    Valor = 3529.00
                };
            }
        }
    }
}
