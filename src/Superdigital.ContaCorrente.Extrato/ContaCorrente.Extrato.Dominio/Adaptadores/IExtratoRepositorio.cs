using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContaCorrente.Extrato.Dominio.Entidades;

namespace ContaCorrente.Extrato.Dominio.Adaptadores
{
    public interface IExtratoRepositorio
    {
        Task<IEnumerable<Lancamento>> ListarLancamentos(Guid idCliente);
    }
}
