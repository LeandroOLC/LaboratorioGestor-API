using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Contatos.Events
{
    public class ContatoExcluidoEvent : BaseContatoEvent
    {
        public ContatoExcluidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
