using LaboratorioGestor.Domain.Contatos;
using LaboratorioGestor.Domain.Contatos.Repository;
using LaboratorioGestor.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Infra.Data.Repository
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(LatoratorioContext context) : base(context) { }

    }
}
