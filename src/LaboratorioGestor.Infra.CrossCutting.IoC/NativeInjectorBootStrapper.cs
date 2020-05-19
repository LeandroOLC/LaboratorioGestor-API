using AutoMapper;
using LaboratorioGestor.Domain.Contatos.Commands;
using LaboratorioGestor.Domain.Contatos.Events;
using LaboratorioGestor.Domain.Contatos.Repository;
using LaboratorioGestor.Domain.Core.Notifications;
using LaboratorioGestor.Domain.Events;
using LaboratorioGestor.Domain.Handlers;
using LaboratorioGestor.Domain.Interfaces;
using LaboratorioGestor.Domain.Laboratorios.Commands;
using LaboratorioGestor.Domain.Laboratorios.Repository;
using LaboratorioGestor.Domain.Proteticos.Commands;
using LaboratorioGestor.Domain.Proteticos.Events;
using LaboratorioGestor.Domain.Proteticos.Repository;
using LaboratorioGestor.Infra.CrossCutting.AspNetFilters;
using LaboratorioGestor.Infra.CrossCutting.Identity.Models;
using LaboratorioGestor.Infra.CrossCutting.Identity.Services;
using LaboratorioGestor.Infra.Data.Context;
using LaboratorioGestor.Infra.Data.Repository;
using LaboratorioGestor.Infra.Data.Repository.EventSourcing;
using LaboratorioGestor.Infra.Data.SqlEventStore;
using LaboratorioGestor.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace LaboratorioGestor.Infra.CrossCutting.IoC
{

    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton(Mapper.Configuration);

            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Domain - Commands
            services.AddScoped<INotificationHandler<RegistrarContatoCommand>, ContatoCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarContatoCommand>, ContatoCommandHandler>();
            services.AddScoped<INotificationHandler<ExcluirContatoCommand>, ContatoCommandHandler>();

            services.AddScoped<INotificationHandler<RegistrarProteticoCommand>, ProteticoCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarProteticoCommand>, ProteticoCommandHandler>();
            services.AddScoped<INotificationHandler<ExcluirProteticoCommand>, ProteticoCommandHandler>();

            services.AddScoped<INotificationHandler<RegistrarLaboratorioCommand>, LaboratorioCommandHandler>();

            // Domain - Eventos
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<ContatoRegistradoEvent>, ContatoEventHandler>();
            services.AddScoped<INotificationHandler<ContatoAtualizadoEvent>, ContatoEventHandler>();
            services.AddScoped<INotificationHandler<ContatoExcluidoEvent>, ContatoEventHandler>();

            services.AddScoped<INotificationHandler<ProteticoRegistradoEvent>, ProteticoEventHandler>();
            services.AddScoped<INotificationHandler<ProteticoAtualizadoEvent>, ProteticoEventHandler>();
            services.AddScoped<INotificationHandler<ProteticoExcluidoEvent>, ProteticoEventHandler>();

            // Infra - Data
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IProteticoRepository, ProteticoRepository>();
            services.AddScoped<ILaboratorioRepository, LaboratorioRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LatoratorioContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IUser, AspNetUser>();

            // Infra - Filtros
            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<ILogger<GlobalActionLogger>, Logger<GlobalActionLogger>>();
            services.AddScoped<GlobalExceptionHandlingFilter>();
            services.AddScoped<GlobalActionLogger>();
        }
    }

}
