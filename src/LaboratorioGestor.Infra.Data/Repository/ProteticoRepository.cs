using LaboratorioGestor.Domain.Proteticos;
using LaboratorioGestor.Domain.Proteticos.Repository;
using LaboratorioGestor.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Infra.Data.Repository
{
    public class ProteticoRepository : Repository<Protetico>, IProteticoRepository
    {
        public ProteticoRepository(LatoratorioContext context) : base(context) { }

    }
}
