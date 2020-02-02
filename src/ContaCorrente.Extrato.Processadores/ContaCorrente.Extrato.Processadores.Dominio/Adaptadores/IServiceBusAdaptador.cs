using ContaCorrente.Extrato.Processadores.Dominio.Entidade;
using System.Threading.Tasks;

namespace ContaCorrente.Extrato.Processadores.Dominio.Adaptadores
{
    public interface IServiceBusAdaptador
    {
        Task EnviarMensagem(Mensagem mensagem);
    }
}
