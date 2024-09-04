using AutoMapper;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class VeiculoProfile : Profile
{
    public VeiculoProfile()
    {
        CreateMap<Veiculo, ListarVeiculoViewModel>()
            .ForMember(vm => vm.Alugado, opt => opt.MapFrom(v => v.Alugado ? "Alugado" : "Livre"))
            .ForMember(vm => vm.GrupoVeiculos, opt => opt.MapFrom(v => v.GrupoVeiculos));

        CreateMap<Veiculo, EditarVeiculoViewModel>()
            .ForMember(vm => vm.GrupoVeiculos, opt => opt.MapFrom<Resolver>());

        CreateMap<CadastroVeiculoViewModel, Veiculo>();
            //.ForMember(vm => vm.Foto, opt => opt.MapFrom<FotoValueResolver>());


        CreateMap<EditarVeiculoViewModel, Veiculo>();


        CreateMap<Veiculo, DetalhesVeiculoViewModel>();
    }
}
//public class FotoValueResolver : IValueResolver<FormVeiculoViewModel, Veiculo, byte[]>
//{
//    public byte[] Resolve(
//        FormVeiculoViewModel source,
//        Veiculo destination,
//        byte[] destMember,
//        ResolutionContext context)
//    {
//        if (source.Foto == null)
//            return null;

//        using (var memoryStream = new MemoryStream())
//        {
//            source.Foto.CopyTo(memoryStream);
//            return memoryStream.ToArray();
//        }
//    }
//}