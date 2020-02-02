using ContaCorrente.Lacamentos.Dominio.Entidades;
using System;

namespace ContaCorrente.Lacamentos.Dominio.Entidade
{
    public class Lancamento : Mensagem
    {
        public Guid IdCliente { get; private set; }
        public string ContaOrigem { get; private set; }
        public string ContaDestino { get; private set; }
        public DateTime Data = DateTime.Now;
        public short Tipo { get; private set; }
        public string Descricao { get; private set; }
        public double Valor { get; private set; }

        public Lancamento(Guid idCliente, string contaOrigem, string contaDestino, short tipo, string descricao, double valor)
        {
            IdCliente = idCliente;
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Tipo = tipo;
            Descricao = descricao;
            Valor = valor;
        }
    }
}
