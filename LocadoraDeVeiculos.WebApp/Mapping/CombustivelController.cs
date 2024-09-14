using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;
using LocadoraDeVeiculos.WebApp.Mapping.Resolvers;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class CombustivelController : Profile
{
    public CombustivelController() 
    {

        CreateMap<FormCombustivelViewModel, Combustivel>()
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

        CreateMap<Combustivel, FormCombustivelViewModel>();
    }
}
