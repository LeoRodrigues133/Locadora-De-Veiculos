using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeVeiculos.WebApp.Mapping
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<Veiculo, ListarVeiculoViewModel>()
                .ForMember(vm => vm.Alugado, opt => opt.MapFrom(v => v.Alugado ? "Alugado" : "Livre"))
                .ForMember(vm => vm.GrupoVeiculos, opt => opt.MapFrom(v => v.GrupoVeiculos));

            CreateMap<Veiculo, EditarVeiculoViewModel>()
                .ForMember(vm => vm.GrupoVeiculos, opt => opt.MapFrom(v => v.GrupoVeiculos));

            CreateMap<CadastroVeiculoViewModel, Veiculo>();

            CreateMap<EditarVeiculoViewModel, Veiculo>();

            CreateMap<Veiculo, DetalhesVeiculoViewModel>();
        }
    }

}