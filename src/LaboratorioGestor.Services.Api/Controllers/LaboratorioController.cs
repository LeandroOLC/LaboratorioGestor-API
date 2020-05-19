using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LaboratorioGestor.Domain.Core.Notifications;
using LaboratorioGestor.Domain.Interfaces;
using LaboratorioGestor.Domain.Laboratorios.Commands;
using LaboratorioGestor.Domain.Laboratorios.Repository;
using LaboratorioGestor.Services.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioGestor.Services.Api.Controllers
{

    public class EventosController : BaseController
    {
        private readonly ILaboratorioRepository _laboratorioRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public EventosController(INotificationHandler<DomainNotification> notifications,
                                 IUser user,
                                 ILaboratorioRepository laboratorioRepository,
                                 IMapper mapper,
                                 IMediatorHandler mediator) : base(notifications, user, mediator)
        {
            _laboratorioRepository = laboratorioRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("laboratorio")]
        [AllowAnonymous]
        public IEnumerable<LaboratorioViewModel> Get()
        {
            return _mapper.Map<IEnumerable<LaboratorioViewModel>>(_laboratorioRepository.ObterTodos());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("laboratorio/{id:guid}")]
        public LaboratorioViewModel Get(Guid id, int version)
        {
            return _mapper.Map<LaboratorioViewModel>(_laboratorioRepository.ObterPorId(id));
        }

      
        [HttpPost]
        [Route("laboratorio")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Post([FromBody]LaboratorioViewModel laboratorioViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var eventoCommand = _mapper.Map<RegistrarLaboratorioCommand>(laboratorioViewModel);

            _mediator.EnviarComando(eventoCommand);
            return Response(eventoCommand);
        }

        private bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;

            NotificarErroModelInvalida();
            return false;
        }
    }
}