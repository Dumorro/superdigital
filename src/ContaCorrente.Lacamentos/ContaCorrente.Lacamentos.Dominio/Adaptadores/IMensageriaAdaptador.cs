using ContaCorrente.Lacamentos.Dominio.Entidades;
using System.Threading.Tasks;

namespace ContaCorrente.Lacamentos.Dominio.Adaptadores
{
    public interface IMensageriaAdaptador
    {
        Task EnviarMensagem(Mensagem mensagem);
    }
}
