using System.Threading.Tasks;
using ContaCorrente.Extrato.Processadores.Dominio.Adaptadores;
using ContaCorrente.Extrato.Processadores.Dominio.Entidade;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace ContaCorrente.Extrato.Processadores.Aplicacao.Servicos
{
    public class ProcessadorDeLacamento : IConsumer<Lancamento>
    {
        private readonly ILogger<ProcessadorDeLacamento> _logger;
        private readonly IExtratoRepositorio _extratoRepositorio;
        public ProcessadorDeLacamento(ILogger<ProcessadorDeLacamento> logger, IExtratoRepositorio extratoRepositorio)
        {
            _logger = logger;
            _extratoRepositorio = extratoRepositorio;
        }

        public async Task Consume(ConsumeContext<Lancamento> context)
        {
            _logger.LogInformation($"Lacamento: {context.Message}");
            await _extratoRepositorio.SalvarLancamento(context.Message);
        }
    }
}
