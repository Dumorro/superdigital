using ContaCorrente.Extrato.Processadores.Dominio.Enumeradores;
using System;

namespace ContaCorrente.Extrato.Processadores.Dominio.Entidade
{
    public class Lancamento : Mensagem
    {
        public Guid IdCliente { get; set; }
        public string ContaOrigem { get; set; }
        public string ContaDestino { get; set; }
        public DateTime Data { get; set; }
        public TipoDeLancamento Tipo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}
