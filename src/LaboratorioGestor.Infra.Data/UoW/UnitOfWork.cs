using LaboratorioGestor.Domain.Interfaces;
using LaboratorioGestor.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LatoratorioContext _context;

        public UnitOfWork(LatoratorioContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
