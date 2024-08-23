using AutoMapper;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class GrupoVeiculosProfile : Profile
{
    public GrupoVeiculosProfile()
    {

        CreateMap<GrupoVeiculos, ListarGrupoViewModel>();

        CreateMap<GrupoViewModels, GrupoVeiculos>();

        CreateMap<EditarGrupoViewModel, GrupoVeiculos>();

        CreateMap<GrupoVeiculos, EditarGrupoViewModel>()
            .ForMember(vm => vm.Nome, opt => opt.MapFrom(g => g.Nome));
    }
}