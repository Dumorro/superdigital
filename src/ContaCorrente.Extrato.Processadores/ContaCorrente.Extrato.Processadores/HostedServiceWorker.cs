using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Logging.Tracing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContaCorrente.Extrato.Processadores
{
    public class HostedServiceWorker: IHostedService
    {
        private readonly IBusControl _busControl;

        public HostedServiceWorker(IBusControl busControl, ILoggerFactory loggerFactory)
        {   
            _busControl = busControl;

            if (loggerFactory != null && MassTransit.Logging.Logger.Current.GetType() == typeof(TraceLogger))
                MassTransit.ExtensionsLoggingIntegration.ExtensionsLogger.Use(loggerFactory);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _busControl.StartAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _busControl.StopAsync(cancellationToken);
        }
    }
}
