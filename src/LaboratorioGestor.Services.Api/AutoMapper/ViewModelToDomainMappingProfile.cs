using AutoMapper;
using LaboratorioGestor.Domain.Contatos.Commands;
using LaboratorioGestor.Domain.Laboratorios.Commands;
using LaboratorioGestor.Domain.Proteticos.Commands;
using LaboratorioGestor.Services.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.Services.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ContatoViewModel, RegistrarContatoCommand>();

            CreateMap<ContatoViewModel, AtualizarContatoCommand>();

            CreateMap<ContatoViewModel, ExcluirContatoCommand>();


            CreateMap<ProteticoViewModel, ExcluirProteticoCommand>();

            CreateMap<ProteticoViewModel, AtualizarProteticoCommand>();

            CreateMap<ProteticoViewModel, ExcluirProteticoCommand>();


            CreateMap<LaboratorioViewModel, RegistrarLaboratorioCommand>();

        }
    }
}