using ContaCorrente.Extrato.Processadores.Dominio.Adaptadores;
using ContaCorrente.Extrato.Processadores.Dominio.Entidade;
using ContaCorrente.Extrato.Processadores.Dominio.Models;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContaCorrente.Extrato.Processadores.Infra.Mensageria
{
    public class ServiceBusAdaptador : IServiceBusAdaptador
    {
        private static ILogger<ServiceBusAdaptador> _logger;
        private static IQueueClient _queueClient;
        private static IExtratoRepositorio _extratoRepositorio;
        public ServiceBusAdaptador(ILogger<ServiceBusAdaptador> logger, IExtratoRepositorio extratoRepositorio, DadosDeConfigacaoDaMensageria dadosDeConfigacao)
        {
            _queueClient = new QueueClient(dadosDeConfigacao.Conexao, dadosDeConfigacao.NomeDaFila, ReceiveMode.PeekLock);
            _extratoRepositorio = extratoRepositorio;
            _logger = logger;
        }

        private static Task EnviarMensagem(Lancamento mensagem)
        {
            _extratoRepositorio.SalvarLancamento(mensagem);
            return Task.CompletedTask;
        }

        private static void ReceberEManipularMensagens()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _queueClient.RegisterMessageHandler(ProcessarMensagensAsync, messageHandlerOptions);
        }

        private static async Task ProcessarMensagensAsync(Message message, CancellationToken token)
        {
            var mensagem = Encoding.UTF8.GetString(message.Body);
            _logger.LogInformation($"Mensagem recebida: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{mensagem}");
            var lancamento = JsonConvert.DeserializeObject<Lancamento>(mensagem);
            await EnviarMensagem(lancamento);
            await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            _logger.LogInformation($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            return Task.CompletedTask;
        }

        public void ProcessarMensagens()
        {
            ReceberEManipularMensagens();
        }

    }
}
