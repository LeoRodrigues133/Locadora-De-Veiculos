using AutoMapper;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.WebApp.Mapping.Resolvers;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class GrupoVeiculosProfile : Profile
{
    public GrupoVeiculosProfile()
    {

        CreateMap<GrupoVeiculos, ListarGrupoViewModel>();

        CreateMap<GrupoVeiculos, FormGrupoViewModel>();

        CreateMap<FormGrupoViewModel, GrupoVeiculos>()
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

        CreateMap<FormGrupoViewModel, GrupoVeiculos>();

        CreateMap<GrupoVeiculos, FormGrupoViewModel>();

        CreateMap<GrupoVeiculos, FormGrupoViewModel>();
    }
}