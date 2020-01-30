namespace ContaCorrente.Extrato.Dominio.Base
{
    public interface IDomainEventHandler<T> where T : DomainEvent
    {
        void Handle(T evento);
    }
}
