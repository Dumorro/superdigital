using System;

namespace ContaCorrente.Lacamentos.Aplicacao.Dtos
{
    public class LancamentoDto
    {
        public Guid IdCliente { get; set; }
        public string ContaOrigem { get; set; }
        public string ContaDestino { get; set; }
        public DateTime Data { get; set; }
        public short Tipo { get; set; }
        public double Valor { get; set; }
    }
}
