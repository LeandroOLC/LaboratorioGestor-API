using MediatR;

namespace LaboratorioGestor.Domain.Laboratorios.Events
{
    public class LaboratorioEventHandler : INotificationHandler<LaboratorioRegistradoEvent>
    {
        public void Handle(LaboratorioRegistradoEvent notification)
        {
            // TODO: Enviar um email?
        }
    }
}
