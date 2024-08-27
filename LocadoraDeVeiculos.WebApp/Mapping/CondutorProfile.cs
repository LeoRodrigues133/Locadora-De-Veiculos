using AutoMapper;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class CondutorProfile : Profile
{
    public CondutorProfile()
    {
        CreateMap<CadastroCondutorViewModel, Condutor>();

        CreateMap<Condutor, EditarCondutorViewModel>()
            .ForMember(vm => vm.Clientes, opt => opt.MapFrom<Resolver>());

        CreateMap<EditarCondutorViewModel, Condutor>();

        CreateMap<Condutor, ExcluirCondutorViewModel>();

        CreateMap<Condutor, DetalhesCondutorViewModel>();

        CreateMap<Condutor, ListarCondutorViewModel>();
    }
}
