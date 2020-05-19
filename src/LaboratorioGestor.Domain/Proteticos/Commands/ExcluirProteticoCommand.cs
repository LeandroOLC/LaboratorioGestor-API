using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Proteticos.Commands
{
    public class ExcluirProteticoCommand : BaseProteticoCommand
    {
        public ExcluirProteticoCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
