using AutoMapper;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraDeVeiculos.WebApp.Mapping.Resolvers;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class CombustivelProfile : Profile
{
    public CombustivelProfile() 
    {

        CreateMap<FormCombustivelViewModel, Combustivel>()
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

        CreateMap<Combustivel, FormCombustivelViewModel>();
    }
}
