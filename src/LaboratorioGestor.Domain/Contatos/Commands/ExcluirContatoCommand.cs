using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Contatos.Commands
{
    public class ExcluirContatoCommand : BaseContatoCommand
    {
        public ExcluirContatoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
