using Autofac;
using ContaCorrente.Extrato.Dominio.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Superdigital.ContaCorrente.ExpedidorDeEventos
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {

        private readonly IComponentContext _container;
        public DomainEventDispatcher(IComponentContext container)
        {
            _container = container;
        }

        public async Task Dispatch(DomainEvent domainEvent)
        {
            Type handlerType = typeof(IHandle<>).MakeGenericType(domainEvent.GetType());
            Type wrapperType = typeof(DomainEventHandler<>).MakeGenericType(domainEvent.GetType());

            IEnumerable handlers = (IEnumerable)_container.Resolve(typeof(IEnumerable<>).MakeGenericType(handlerType));

            if (handlers == null)
                return;

            IList<DomainEventHandler> wrappedHandlers = GetHandlers(wrapperType, handlers);
            await SendEvents(domainEvent, wrappedHandlers);
        }

        private static async Task SendEvents(DomainEvent domainEvent, IList<DomainEventHandler> wrappedHandlers)
        {
            foreach (DomainEventHandler handler in wrappedHandlers)
            {
                await handler.Handle(domainEvent);
            }
        }

        private static IList<DomainEventHandler> GetHandlers(Type wrapperType, IEnumerable handlers)
        {
            IList<DomainEventHandler> wrappedHandlers = new List<DomainEventHandler>();

            foreach (var handler in handlers)
            {
                wrappedHandlers.Add((DomainEventHandler)Activator.CreateInstance(wrapperType, handler));
            }

            return wrappedHandlers;
        }
    }
}