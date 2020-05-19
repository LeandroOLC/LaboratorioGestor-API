using LaboratorioGestor.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Contatos.Events
{
    public class ContatoEventHandler :
        INotificationHandler<ContatoRegistradoEvent>,
        INotificationHandler<ContatoAtualizadoEvent>,
        INotificationHandler<ContatoExcluidoEvent>
    {
        public void Handle(ContatoRegistradoEvent message)
        {
            // TODO: Disparar alguma ação
        }

        public void Handle(ContatoAtualizadoEvent message)
        {
            // TODO: Disparar alguma ação
        }

        public void Handle(ContatoExcluidoEvent message)
        {
            // TODO: Disparar alguma ação
        }
    }
}
