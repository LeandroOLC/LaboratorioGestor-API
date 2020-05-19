using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Proteticos.Events
{

    public class ProteticoEventHandler :
        INotificationHandler<ProteticoRegistradoEvent>,
        INotificationHandler<ProteticoAtualizadoEvent>,
        INotificationHandler<ProteticoExcluidoEvent>
    {
        public void Handle(ProteticoRegistradoEvent message)
        {
            // TODO: Disparar alguma ação
        }

        public void Handle(ProteticoAtualizadoEvent message)
        {
            // TODO: Disparar alguma ação
        }

        public void Handle(ProteticoExcluidoEvent message)
        {
            // TODO: Disparar alguma ação
        }
        
    }
}
