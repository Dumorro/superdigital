using System.Threading.Tasks;

namespace ContaCorrente.Extrato.Dominio.Base
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(DomainEvent evento);
    }
}
