using ContaCorrente.Extrato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContaCorrente.Extrato.Dominio.Servicos
{
    public interface IExtratoDeContaCorrente
    {
        Task<IEnumerable<Lancamento>> ObterLacamentos(Guid idCliente);
    }
}