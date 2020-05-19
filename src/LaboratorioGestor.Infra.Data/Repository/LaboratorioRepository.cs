using LaboratorioGestor.Domain.Laboratorios;
using LaboratorioGestor.Domain.Laboratorios.Repository;
using LaboratorioGestor.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Infra.Data.Repository
{
    public class LaboratorioRepository : Repository<Laboratorio>, ILaboratorioRepository
    {
        public LaboratorioRepository(LatoratorioContext context) : base(context) { }

    }
}
