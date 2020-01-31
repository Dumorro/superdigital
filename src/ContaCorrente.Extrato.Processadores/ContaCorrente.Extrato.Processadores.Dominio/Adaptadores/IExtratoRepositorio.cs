using ContaCorrente.Extrato.Processadores.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.Extrato.Processadores.Dominio.Adaptadores
{
    public interface IExtratoRepositorio
    {
        Task SalvarLancamento(Lancamento lancamento);
    }
}
