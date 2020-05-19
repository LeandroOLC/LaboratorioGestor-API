using AutoMapper;
using LaboratorioGestor.Domain.Contatos;
using LaboratorioGestor.Domain.Laboratorios;
using LaboratorioGestor.Domain.Proteticos;
using LaboratorioGestor.Services.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.Services.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Contato, ContatoViewModel>();
            CreateMap<Laboratorio, LaboratorioViewModel>();
            CreateMap<Protetico, ProteticoViewModel>();
        }

    }
}
