using AutoMapper;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<CadastroClienteViewModel, Cliente>();

        CreateMap<Cliente, EditarClienteViewModel>();

        CreateMap<EditarClienteViewModel, Cliente>();

        CreateMap<Cliente, ExcluirClienteViewModel>();

        CreateMap<Cliente, DetalhesClienteViewModel>();

        CreateMap<Cliente, ListarClienteViewModel>()
            .ForMember(vm => vm.tipoCliente, opt => opt.MapFrom(c => c.TipoPerfil ?  "Pessoa Física" : "Pessoa Jurídica" ));
    }
}
