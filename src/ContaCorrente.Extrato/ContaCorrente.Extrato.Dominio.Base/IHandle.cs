using System.Threading.Tasks;

namespace ContaCorrente.Extrato.Dominio.Base
{
    public interface IHandle<T> where T : DomainEvent
    {
        Task Handle(T domainEvent);
    }
}