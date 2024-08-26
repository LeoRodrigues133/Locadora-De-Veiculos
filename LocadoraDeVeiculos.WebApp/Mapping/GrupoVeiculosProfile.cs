using AutoMapper;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class GrupoVeiculosProfile : Profile
{
    public GrupoVeiculosProfile()
    {

        CreateMap<GrupoVeiculos, ListarGrupoViewModel>();

        CreateMap<GrupoVeiculos, EditarGrupoViewModel>();

        CreateMap<CadastroGrupoViewModel, GrupoVeiculos>();

        CreateMap<EditarGrupoViewModel, GrupoVeiculos>();

        CreateMap<GrupoVeiculos, DetalhesGrupoViewModel>();

        CreateMap<GrupoVeiculos, ExcluirGrupoViewModel>();
    }
}