using ContaCorrente.Extrato.Aplicacao.Dtos;
using System;
using System.Threading.Tasks;

namespace ContaCorrente.Extrato.Aplicacao.Servicos
{
    public interface IConsultaDeExtrato
    {
        Task<ExtratoDto> Obter(Guid idCliente);
    }
}
