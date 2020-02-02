using ContaCorrente.Lacamentos.Dominio.Entidades;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.Lacamentos.Infra.Mensageria
{
    public class ServiceBusSender
    {
        private readonly QueueClient _queueClient;

        public ServiceBusSender(DadosDeConfiguracaoDoServicoDeMensageria configuracao)
        {
            _queueClient = new QueueClient(configuracao.Conexao, configuracao.NomeDaFila);
        }

        public async Task Send(Mensagem mensagem)
        {
            string data = JsonConvert.SerializeObject(mensagem);
            Message message = new Message(Encoding.UTF8.GetBytes(data));

            await _queueClient.SendAsync(message);
        }
    }
}
