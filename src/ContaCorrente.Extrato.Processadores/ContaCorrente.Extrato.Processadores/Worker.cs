using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContaCorrente.Extrato.Processadores.Dominio.Adaptadores;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContaCorrente.Extrato.Processadores
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, IServiceBusAdaptador serviceBusAdaptador)
        {
            _logger = logger;
            serviceBusAdaptador.ProcessarMensagens();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
