using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<Veiculo, ListarVeiculoViewModel>()
                .ForMember(vm => vm.Alugado, opt => opt.MapFrom(v => v.Alugado ? "Alugado" : "Livre"))
                .ForMember(vm => vm.grupoVeiculos, opt => opt.MapFrom(v => v.GrupoVeiculosId));


            CreateMap<CadastroVeiculoViewModel, Veiculo>();

            CreateMap<EditarVeiculoViewModel, Veiculo>();

            CreateMap<Veiculo, EditarVeiculoViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(v => v.Id))
                .ForMember(vm => vm.Cor, opt => opt.MapFrom(v => v.Cor))
                .ForMember(vm => vm.Marca, opt => opt.MapFrom(v => v.Marca))
                .ForMember(vm => vm.Combustivel, opt => opt.MapFrom(v => v.Combustivel))
                .ForMember(vm => vm.grupoVeiculos, opt => opt.MapFrom(v => v.GrupoVeiculos)) // <-- adicionado
                .ForMember(vm => vm.CategoriaVeiculo, opt => opt.MapFrom(v => v.CategoriaVeiculo))
                .ForMember(vm => vm.Ano, opt => opt.MapFrom(v => v.Ano))
                .ForMember(vm => vm.Placa, opt => opt.MapFrom(v => v.Placa))
                .ForMember(vm => vm.Modelo, opt => opt.MapFrom(v => v.Modelo))
                .ForMember(vm => vm.Alugado, opt => opt.MapFrom(v => v.Alugado))
                .ForMember(vm => vm.Quilometragem, opt => opt.MapFrom(v => v.Quilometragem))
                .ForMember(vm => vm.CapacidadeTanqueDeCombustivel, opt => opt.MapFrom(v => v.CapacidadeTanqueDeCombustivel));

            CreateMap<Veiculo, DetalhesVeiculoViewModel>();

        }
    }

}