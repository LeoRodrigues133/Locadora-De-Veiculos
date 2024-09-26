using AutoMapper;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.WebApp.Mapping.Resolvers;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class VeiculoProfile : Profile
{
    public VeiculoProfile()
    {
        CreateMap<Veiculo, ListarVeiculoViewModel>()
            .ForMember(vm => vm.Alugado, opt => opt.MapFrom(v => v.Alugado ? "Alugado" : "Livre"))
            .ForMember(vm => vm.GrupoVeiculos, opt => opt.MapFrom(v => v.GrupoVeiculos));

        CreateMap<Veiculo, FormVeiculoViewModel>()
            .ForMember(vm => vm.GrupoVeiculos, opt => opt.MapFrom<Resolver>());

        CreateMap<FormVeiculoViewModel, Veiculo>()
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());
            //.ForMember(vm => vm.Foto, opt => opt.MapFrom<FotoValueResolver>());

    }
}