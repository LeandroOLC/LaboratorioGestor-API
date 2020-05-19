using LaboratorioGestor.Domain.Contatos;
using LaboratorioGestor.Domain.Contatos.Commands;
using LaboratorioGestor.Domain.Contatos.Events;
using LaboratorioGestor.Domain.Core.Notifications;
using LaboratorioGestor.Domain.Handlers;
using LaboratorioGestor.Domain.Interfaces;
using LaboratorioGestor.Domain.Proteticos.Events;
using LaboratorioGestor.Domain.Proteticos.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Proteticos.Commands
{
    public class ProteticoCommandHandler : CommandHandler,
        INotificationHandler<RegistrarProteticoCommand>,
        INotificationHandler<AtualizarProteticoCommand>,
        INotificationHandler<ExcluirProteticoCommand>
    {
        private readonly IProteticoRepository _proteticoRepository;
        private readonly IUser _user;
        private readonly IMediatorHandler _mediator;

        public ProteticoCommandHandler(IProteticoRepository proteticoRepository,
                                    IUnitOfWork uow,
                                    INotificationHandler<DomainNotification> notifications,
                                    IUser user,
                                    IMediatorHandler mediator) : base(uow, mediator, notifications)
        {
            _proteticoRepository = proteticoRepository;
            _user = user;
            _mediator = mediator;
        }

        public void Handle(RegistrarProteticoCommand message)
        {
            var contato = new Contato(
                message.Contato.Id,
                message.Contato.Fone1,
                message.Contato.Fone2,
                message.Contato.Celular,
                message.Contato.CelularWhatApp,
                message.Contato.DataDoCadastro,
                message.Contato.TipoContato,
                message.Contato.Email);

            var protetico = Protetico.ProteticoFactory.NovoProteticoCompleto(
                message.Id,
                message.Nome,
                message.PercentualDaComissao,
                message.DataDoCadastro,
                message.CPF,
                message.IDContato,
                contato);

            if (!ProteticoValido(protetico)) return;

            // TODO:
            // Validacoes de negocio!

            _proteticoRepository.Adicionar(protetico);

            if (Commit())
            {
                _mediator.PublicarEvento(new ProteticoRegistradoEvent(
                protetico.Id,
                protetico.Nome,
                protetico.PercentualDaComissao,
                protetico.DataDoCadastro,
                protetico.CPF,
                protetico.IDContato));
            }
        }

        public void Handle(AtualizarProteticoCommand message)
        {
            var protetivoAtual = _proteticoRepository.ObterPorId(message.Id);

            if (!EventoExistente(message.Id, message.MessageType)) return;

            var evento = Protetico.ProteticoFactory.NovoProteticoCompleto(
                message.Id,
                message.Nome,
                message.PercentualDaComissao,
                message.DataDoCadastro,
                message.CPF,
                message.IDContato,
                protetivoAtual.Contatos);

     
            if (!ProteticoValido(evento)) return;

            _proteticoRepository.Atualizar(evento);

            if (Commit())
            {
                _mediator.PublicarEvento(new ProteticoAtualizadoEvent(
                evento.Id,
                evento.Nome,
                evento.PercentualDaComissao,
                evento.DataDoCadastro,
                evento.CPF));
            }
        }
       
        public void Handle(ExcluirProteticoCommand message)
        {
            if (!EventoExistente(message.Id, message.MessageType)) return;
            
            var proteticoAtual = _proteticoRepository.ObterPorId(message.Id);

            _proteticoRepository.Atualizar(proteticoAtual);

            if (Commit())
            {
                _mediator.PublicarEvento(new ContatoExcluidoEvent(message.Id));
            }
        }

        private bool ProteticoValido(Protetico protetico)
        {
            if (protetico.EhValido()) return true;

            NotificarValidacoesErro(protetico.ValidationResult);
            return false;
        }

        private bool EventoExistente(Guid id, string messageType)
        {
            var evento = _proteticoRepository.ObterPorId(id);

            if (evento != null) return true;

            _mediator.PublicarEvento(new DomainNotification(messageType, "Protetico não encontrado."));
            return false;
        }
    }
}