using System;

namespace ContaCorrente.Extrato.Dominio.Base
{
    public abstract class DomainEvent
    {
        public DateTime DateTimeOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
