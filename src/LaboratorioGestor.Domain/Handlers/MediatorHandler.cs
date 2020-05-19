using LaboratorioGestor.Domain.Core.Commands;
using LaboratorioGestor.Domain.Core.Events;
using LaboratorioGestor.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Domain.Handlers
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public MediatorHandler(IMediator mediator, IEventStore eventStore)
        {
            _mediator = mediator;
            _eventStore = eventStore;
        }

        public Task EnviarComando<T>(T comando) where T : Command
        {
            return Publicar(comando);
        }

        public Task PublicarEvento<T>(T evento) where T : Event
        {
            if (!evento.MessageType.Equals("DomainNotification"))
                _eventStore?.SalvarEvento(evento);

            return Publicar(evento);
        }

        private Task Publicar<T>(T mensagem) where T : Message
        {
            return _mediator.Publish(mensagem);
        }
    }
}
