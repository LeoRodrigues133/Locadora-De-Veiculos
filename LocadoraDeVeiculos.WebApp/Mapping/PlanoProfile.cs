using AutoMapper;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class PlanoProfile : Profile
{
    public PlanoProfile()
    {
        CreateMap<Plano, ListarPlanoViewModel>()
            .ForMember(vm => vm.GrupoVeiculos, opt => opt.MapFrom(v => v.GrupoVeiculos));

        CreateMap<Plano, EditarPlanoViewModel>();

        CreateMap<CadastroPlanoViewModel, Plano>();

        CreateMap<EditarPlanoViewModel, Plano>();

        CreateMap<Plano, DetalhesPlanoViewModel>();
    }
}
