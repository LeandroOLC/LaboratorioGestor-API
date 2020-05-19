using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Proteticos.Events
{
    public class ProteticoExcluidoEvent : BaseProteticoEvent
    {
        public ProteticoExcluidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
