using AutoMapper;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.WebApp.Mapping.Resolvers;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class PlanoProfile : Profile
{
    public PlanoProfile()
    {
        CreateMap<Plano, ListarPlanoViewModel>()
            .ForMember(vm => vm.GrupoVeiculos, opt => opt.MapFrom(v => v.GrupoVeiculos));

        CreateMap<Plano, FormPlanoViewModels>()
            .ForMember(vm => vm.GrupoVeiculos, opt => opt.MapFrom<Resolver>());

        CreateMap<FormPlanoViewModels, Plano>()
            .ForMember(vm => vm.GrupoVeiculos, opt => opt.MapFrom(p => p.GrupoVeiculos))
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

    }
}
