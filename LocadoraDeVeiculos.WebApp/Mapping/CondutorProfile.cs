using AutoMapper;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.WebApp.Mapping.Resolvers;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class CondutorProfile : Profile
{
    public CondutorProfile()
    {
        CreateMap<FormCondutorViewModel, Condutor>()
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>())
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(c => c.Cliente));

        CreateMap<Condutor, FormCondutorViewModel>()
            .ForMember(vm => vm.Clientes, opt => opt.MapFrom<Resolver>());

        CreateMap<Condutor, ListarCondutorViewModel>();
    }
}
