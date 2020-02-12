using ContaCorrente.Extrato.Processadores.Dominio.Adaptadores;
using ContaCorrente.Extrato.Processadores.Dominio.Entidade;
using Microsoft.Azure.ServiceBus;
using System.Threading.Tasks;

namespace ContaCorrente.Extrato.Processadores.Infra.Mensageria
{
    public class ServiceBusAdaptador : IServiceBusAdaptador
    {
        public readonly TopicClient _topicClient;
        public ServiceBusAdaptador()
        {
            _topicClient = new TopicClient();
        }

        public Task EnviarMensagem(Mensagem mensagem)
        {
            throw new System.NotImplementedException();
        }
    }
}
