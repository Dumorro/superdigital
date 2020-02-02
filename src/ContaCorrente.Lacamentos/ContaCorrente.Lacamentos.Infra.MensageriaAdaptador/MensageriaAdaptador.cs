using ContaCorrente.Lacamentos.Dominio.Adaptadores;
using ContaCorrente.Lacamentos.Dominio.Entidades;
using System.Threading.Tasks;

namespace ContaCorrente.Lacamentos.Infra.Mensageria
{
    public class MensageriaAdaptador : IMensageriaAdaptador
    {
        private readonly DadosDeConfiguracaoDoServicoDeMensageria _configuracao;
        public MensageriaAdaptador(DadosDeConfiguracaoDoServicoDeMensageria configuracao)
        {
            _configuracao = configuracao;
        }

        public async Task EnviarMensagem(Mensagem mensagem)
        {
            var servico = new ServiceBusSender(_configuracao);
            await servico.Send(mensagem);
        }
    }
}
