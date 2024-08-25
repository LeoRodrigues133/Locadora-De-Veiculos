using AutoMapper;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class VeiculoProfile : Profile
{
    public VeiculoProfile()
    {
        CreateMap<Veiculo, ListarVeiculoViewModel>()
            .ForMember(vm => vm.Alugado, opt => opt.MapFrom(v => v.Alugado ? "Alugado" : "Livre"))
            .ForMember(vm => vm.GrupoVeiculos, opt => opt.MapFrom(v => v.GrupoVeiculos));

        CreateMap<Veiculo, EditarVeiculoViewModel>()
            .ForMember(vm => vm.GrupoVeiculos, opt => opt.MapFrom<GrupoResolver>());

        CreateMap<CadastroVeiculoViewModel, Veiculo>();

        CreateMap<EditarVeiculoViewModel, Veiculo>();

        CreateMap<Veiculo, DetalhesVeiculoViewModel>();
    }


    public class GrupoResolver : IValueResolver<Veiculo, EditarVeiculoViewModel, IEnumerable<SelectListItem>?>
    {
        readonly IRepositorioGrupoVeiculos _repositorioGrupo;

        public GrupoResolver(IRepositorioGrupoVeiculos repositorioGrupo)
        {
            _repositorioGrupo = repositorioGrupo;
        }

        public IEnumerable<SelectListItem> Resolve(Veiculo source, EditarVeiculoViewModel destination, IEnumerable<SelectListItem> destMember, ResolutionContext context)
        {
            return _repositorioGrupo
                .SelecionarTodos()
                .Select
                (Grupo => new SelectListItem(Grupo.Nome, Grupo.Id.ToString()));
        }
    }
}