﻿using LaboratorioGestor.Domain.Core.Commands;
using LaboratorioGestor.Domain.Core.Events;
using System.Threading.Tasks;

namespace LaboratorioGestor.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task EnviarComando<T>(T comando) where T : Command;
    }
}
