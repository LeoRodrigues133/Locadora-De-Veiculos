using AutoMapper;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.WebApp.Mapping.Resolvers;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class AluguelProfile : Profile
{
    public AluguelProfile()
    {
        CreateMap<Aluguel, ListarAluguelViewModel>()
            .ForMember(vm => vm.Condutor, opt => opt.MapFrom(v => v.Condutor.Nome.ToString()))
            .ForMember(vm => vm.Plano, opt => opt.MapFrom(v => v.Plano.TipoPlano.ToString()))
            .ForMember(vm => vm.Veiculo, opt => opt.MapFrom(v => v.Veiculo.Modelo.ToString()))
            .ForMember(vm => vm.Grupo, opt => opt.MapFrom(v => v.Grupo.Nome.ToString()));


        CreateMap<Aluguel, FinalizarAluguelViewModel>()
            .ForMember(vm => vm.Aluguel, opt => opt.MapFrom(c => c))
            .ForMember(vm => vm.Id, opt => opt.MapFrom(c => c.Id))
            .ForMember(vm => vm.Grupos, opt => opt.MapFrom<Resolver>())
            .ForMember(vm => vm.Planos, opt => opt.MapFrom<Resolver>())
            .ForMember(vm => vm.Veiculos, opt => opt.MapFrom<Resolver>())
            .ForMember(vm => vm.Clientes, opt => opt.MapFrom<Resolver>())
            .ForMember(vm => vm.Condutores, opt => opt.MapFrom<Resolver>());

        CreateMap<CadastroAluguelViewModel, Aluguel>()
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

        CreateMap<Aluguel, PrefinalizarAluguelViewModel>()
            .ForMember(vm => vm.Aluguel, opt => opt.MapFrom(c => c))
            .ForMember(vm => vm.KmFinal, opt => opt.MapFrom(c => c.Veiculo.Quilometragem))
            .ForMember(vm => vm.Taxas, opt => opt.MapFrom(c => c.Taxas)) ;

        CreateMap<PrefinalizarAluguelViewModel, Aluguel>()
            .ForMember(vm => vm.Id, opt => opt.MapFrom(c => c.Aluguel.Id))
            .ForMember(vm => vm.KmFinal, opt => opt.MapFrom(c => c.Aluguel.KmFinal))
            .ForMember(vm => vm.Taxas, opt => opt.MapFrom(c => c.Taxas));

        CreateMap<Aluguel, ExcluirAluguelViewModel>();

        CreateMap<Aluguel, DetalhesAluguelViewModel>()
            .ForMember(vm => vm.Taxas, opt => opt.MapFrom(c => c.Taxas)); ;
    }
}
