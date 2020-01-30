using ContaCorrente.Extrato.Aplicacao.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;
using ContaCorrente.Extrato.Aplicacao.Mapeadores;
using ContaCorrente.Extrato.Dominio.Servicos;

namespace ContaCorrente.Extrato.Aplicacao.Servicos
{
    public class ConsultaDeExtrato : IConsultaDeExtrato
    {
        private readonly IExtratoDeContaCorrente _extratoDeConta;

        public ConsultaDeExtrato(IExtratoDeContaCorrente extratoDeConta)
        {
            _extratoDeConta = extratoDeConta;
        }

        public async Task<ExtratoDto> Obter(Guid idCliente)
        {
            try
            {
                var lancamentos = await _extratoDeConta.ObterLacamentos(idCliente);
                var extrato = new ExtratoDto()
                {
                    IdCliente = idCliente,
                    Lancamentos = lancamentos.Select(MapeadorDeLancamento.MapearParaDto)
                };

                return extrato;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
