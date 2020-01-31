using System;
using System.Collections;
using System.Collections.Generic;

namespace ContaCorrente.Extrato.Aplicacao.Dtos
{
    public class ExtratoDto
    {
        public Guid IdCliente { get; set; }
        public IEnumerable<LancamentoDto> Lancamentos  { get; set; }
    }
}
