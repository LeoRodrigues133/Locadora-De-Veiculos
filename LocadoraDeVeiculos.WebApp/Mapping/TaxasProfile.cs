using AutoMapper;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class TaxasProfile : Profile
{
    public TaxasProfile()
    {
        CreateMap<TaxaServico, ListarTaxasViewModel>();
        CreateMap< CadastroTaxasViewModel, TaxaServico>();
        CreateMap<TaxaServico, ExcluirTaxasViewModel>();
        CreateMap<TaxaServico, EditarTaxasViewModel>();
        CreateMap<TaxaServico, DetalhesTaxasViewModel>();
        CreateMap<EditarTaxasViewModel, TaxasService>();
    }
}
