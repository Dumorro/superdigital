using ContaCorrente.Extrato.Dominio.Enumeradores;
using System;
using ContaCorrente.Extrato.Dominio.Entidades;

namespace ContaCorrente.Extrato.Aplicacao.Dtos
{
    public class LancamentoDto
    {
        public DateTime Data { get; set; }
        public TipoDeLancamento Tipo { get; set; }     
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string ContaOrigem { get; set; }
        public string ContaDestino { get; set; }
    }
}
