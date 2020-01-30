using System;
using System.Collections.Generic;

namespace ContaCorrente.Extrato.Dominio.Entidades
{
    public class ExtratoDaContaCorrenteEmCache
    {
        public Guid IdCliente { get; set; }
        public IEnumerable<Lancamento> Lancamentos { get; set; }
    }
}