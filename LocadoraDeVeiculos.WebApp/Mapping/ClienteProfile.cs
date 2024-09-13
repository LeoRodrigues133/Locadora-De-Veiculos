using AutoMapper;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.WebApp.Mapping.Resolvers;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<CadastroClienteViewModel, Cliente>()
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

        CreateMap<Cliente, EditarClienteViewModel>();

        CreateMap<EditarClienteViewModel, Cliente>();

        CreateMap<Cliente, ExcluirClienteViewModel>();

        CreateMap<Cliente, DetalhesClienteViewModel>();

        CreateMap<Cliente, ListarClienteViewModel>()
            .ForMember(x => x.Cliente, opt => opt.MapFrom(cliente => cliente))
            .ForMember(vm => vm.tipoCliente, opt => opt.MapFrom(c => c.TipoPerfil ?  "Pessoa Física" : "Pessoa Jurídica" ));
    }
}
