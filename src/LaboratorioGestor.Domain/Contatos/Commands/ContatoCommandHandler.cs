using LaboratorioGestor.Domain.Contatos.Events;
using LaboratorioGestor.Domain.Contatos.Repository;
using LaboratorioGestor.Domain.Core.Notifications;
using LaboratorioGestor.Domain.Events;
using LaboratorioGestor.Domain.Handlers;
using LaboratorioGestor.Domain.Interfaces;
using LaboratorioGestor.Domain.Proteticos.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Contatos.Commands
{
    public class ContatoCommandHandler : CommandHandler,
        INotificationHandler<RegistrarContatoCommand>,
        INotificationHandler<AtualizarContatoCommand>,
        INotificationHandler<ExcluirContatoCommand>

    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IUser _user;
        private readonly IMediatorHandler _mediator;

        public ContatoCommandHandler(IContatoRepository contatoRepository,
                                    IUnitOfWork uow,
                                    INotificationHandler<DomainNotification> notifications,
                                    IUser user,
                                    IMediatorHandler mediator) : base(uow, mediator, notifications)
        {
            _contatoRepository = contatoRepository;
            _user = user;
            _mediator = mediator;
        }

        public void Handle(RegistrarContatoCommand message)
        {
            var contato = new Contato(
                message.Id,
                message.Fone1,
                message.Fone2,
                message.Celular,
                message.CelularWhatApp,
                message.DataDoCadastro,
                message.TipoContato,
                message.Email);


            if (!ContatoValido(contato)) return;

            // TODO:
            // Validacoes de negocio!

            _contatoRepository.Adicionar(contato);

            if (Commit())
            {
                _mediator.PublicarEvento(new ContatoRegistradoEvent(
                message.Id,
                message.Fone1,
                message.Fone2,
                message.Celular,
                message.CelularWhatApp,
                message.DataDoCadastro,
                message.TipoContato,
                message.Email));
            }
        }

        public void Handle(AtualizarContatoCommand message)
        {
            var contatoAtual = _contatoRepository.ObterPorId(message.Id);

            if (!ContatoExistente(message.Id, message.MessageType)) return;

            var contato = new Contato(
                message.Id,
                message.Fone1,
                message.Fone2,
                message.Celular,
                message.CelularWhatApp,
                message.DataDoCadastro,
                message.TipoContato,
                message.Email);

            if (!ContatoValido(contato)) return;

            _contatoRepository.Atualizar(contato);

            if (Commit())
            {
                _mediator.PublicarEvento(new ContatoAtualizadoEvent(
                contato.Id,
                contato.Fone1,
                contato.Fone2,
                contato.Celular,
                contato.CelularWhatApp,
                contato.DataDoCadastro,
                contato.TipoContato,
                contato.Email));
            }
        }

        public void Handle(ExcluirContatoCommand message)
        {
            if (!ContatoExistente(message.Id, message.MessageType)) return;

            var proteticoAtual = _contatoRepository.ObterPorId(message.Id);

            _contatoRepository.Atualizar(proteticoAtual);

            if (Commit())
            {
                _mediator.PublicarEvento(new ContatoExcluidoEvent(message.Id));
            }
        }

        private bool ContatoValido(Contato contato)
        {
            if (contato.EhValido()) return true;

            NotificarValidacoesErro(contato.ValidationResult);
            return false;
        }

        private bool ContatoExistente(Guid id, string messageType)
        {
            var evento = _contatoRepository.ObterPorId(id);

            if (evento != null) return true;

            _mediator.PublicarEvento(new DomainNotification(messageType, "Contato não encontrado."));
            return false;
        }
    }
}
