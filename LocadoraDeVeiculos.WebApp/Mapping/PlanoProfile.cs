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

        CreateMap<Plano, EditarPlanoViewModel>()
            .ForMember(vm => vm.GrupoVeiculos, opt => opt.MapFrom<Resolver>());

        CreateMap<CadastroPlanoViewModel, Plano>()
            .ForMember(vm => vm.GrupoVeiculos, opt => opt.MapFrom(p => p.GrupoVeiculos))
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

        CreateMap<EditarPlanoViewModel, Plano>();

        CreateMap<Plano, DetalhesPlanoViewModel>();
    }
}
