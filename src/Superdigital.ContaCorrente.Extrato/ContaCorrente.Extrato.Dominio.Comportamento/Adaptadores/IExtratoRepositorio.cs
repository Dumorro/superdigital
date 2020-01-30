using System;
using System.Collections.Generic;
using ContaCorrente.Extrato.Dominio.Entidades;

namespace ContaCorrente.Extrato.Dominio.Comportamento.Adaptadores
{
    public interface IExtratoRepositorio
    {
        IEnumerable<Lacamento> ListarLancamentos(Guid idCliente);
    }
}
