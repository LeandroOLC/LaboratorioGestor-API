using LaboratorioGestor.Domain.Core.Notifications;
using LaboratorioGestor.Domain.Handlers;
using LaboratorioGestor.Domain.Interfaces;
using LaboratorioGestor.Domain.Laboratorios.Events;
using LaboratorioGestor.Domain.Laboratorios.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaboratorioGestor.Domain.Laboratorios.Commands
{
    public class LaboratorioCommandHandler : CommandHandler,
        INotificationHandler<RegistrarLaboratorioCommand>
    {
        private readonly IMediatorHandler _mediator;
        private readonly ILaboratorioRepository _laboratorioRepository;

        public LaboratorioCommandHandler(
            IUnitOfWork uow,
            INotificationHandler<DomainNotification> notifications,
            ILaboratorioRepository organizadorRepository, IMediatorHandler mediator) : base(uow, mediator, notifications)
        {
            _laboratorioRepository = organizadorRepository;
            _mediator = mediator;
        }

        public void Handle(RegistrarLaboratorioCommand message)
        {
            var laboratorio = new Laboratorio
            (
                message.Id,
                message.Nome,
                message.Proprietario,
                message.TPO,
                message.Documento,
                message.TipoPessoa,
                message.DataDoCadastro
            );

            if (!laboratorio.EhValido())
            {
                NotificarValidacoesErro(laboratorio.ValidationResult);
                return;
            }

            var laboratorioExistente = _laboratorioRepository.Buscar(o => o.Documento == laboratorio.Documento);

            if (laboratorioExistente.Any())
            {
                _mediator.PublicarEvento(new DomainNotification(message.MessageType, "Documento já utilizados"));
            }

            _laboratorioRepository.Adicionar(laboratorio);

            if (Commit())
            {
                _mediator.PublicarEvento(new LaboratorioRegistradoEvent
                (               
                    laboratorio.Id,
                    laboratorio.Nome,
                    laboratorio.Proprietario,
                    laboratorio.TPO,
                    laboratorio.Documento,
                    laboratorio.TipoPessoa,
                    laboratorio.DataDoCadastro
                ));
            }
        }
    }
}
