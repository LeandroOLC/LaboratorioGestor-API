using LaboratorioGestor.Domain.Core.Events;

namespace LaboratorioGestor.Domain.Interfaces
{
    public interface IEventStore
    {
        void SalvarEvento<T>(T evento) where T : Event;
    }
}
