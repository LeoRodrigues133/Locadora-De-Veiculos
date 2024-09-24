using LocadoraDeVeiculos.Dominio;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;

namespace LocadoraDeVeiculos.WebApp.Models;

public class FormAluguelViewModel
{
    public int Id { get; set; }
    public List<TaxaServico>? Taxas { get; set; }
    public int Entrada { get; set; } = 1000;
    public IEnumerable<SelectListItem>? Condutores { get; set; }
    public IEnumerable<SelectListItem>? Veiculos { get; set; }
    public IEnumerable<SelectListItem>? Clientes { get; set; }
    public IEnumerable<SelectListItem>? Planos { get; set; }
    public IEnumerable<SelectListItem>? Grupos { get; set; }
    public DateTime DataLocacao { get; set; } = DateTime.UtcNow;
    public DateTime? DateDevolucaoPrevista { get; set; } = DateTime.UtcNow;
    public List<int> taxasSelecionadas { get; set; } = new List<int>();

    public int PlanoId { get; set; }
    public int VeiculoId { get; set; }
    public int GrupoId { get; set; }
    public int CondutorId { get; set; }
    public int ClienteId { get; set; }
    public int SeguroId { get; set; }
    public int TaxaServicoId { get; set; }
    public int KmFinal { get; set; }

}
public class ListarAluguelViewModel : FormAluguelViewModel
{
    public string Condutor { get; set; }
    public string Veiculo { get; set; }
    public string Cliente { get; set; }
    public string Plano { get; set; }
    public string Seguro { get; set; }
    public string Grupo { get; set; }
    public bool encerrado {  get; set; }
}

public class CadastroAluguelViewModel : FormAluguelViewModel
{
    public IEnumerable<SelectListItem>? Condutores { get; set; }
    public IEnumerable<SelectListItem>? Veiculos { get; set; }
    public IEnumerable<SelectListItem>? Clientes { get; set; }
    public IEnumerable<SelectListItem>? Planos { get; set; }
    public IEnumerable<SelectListItem>? Grupos { get; set; }
    public decimal? ValorFinal { get; set; } = 0;
    public EnumMarcadorCombustivel marcadorCombustivel {  get; set; }

}
public class ExcluirAluguelViewModel : FormAluguelViewModel
{
    public Cliente Cliente { get; set; }
    public Condutor Condutor { get; set; }
    public Veiculo Veiculo { get; set; }
    public Plano Plano { get; set; }
    public GrupoVeiculos Grupo { get; set; }
}
public class EditarAluguelViewModel : FormAluguelViewModel
{
    public IEnumerable<SelectListItem>? Condutores { get; set; }
    public IEnumerable<SelectListItem>? Clientes { get; set; }
    public IEnumerable<SelectListItem>? Veiculos { get; set; }
    public IEnumerable<SelectListItem>? Planos { get; set; }
    public IEnumerable<SelectListItem>? Grupos { get; set; }
    public decimal? ValorFinal { get; set; } = 0;
    public List<int> taxasSelecionadas { get; set; } = new List<int>();
}
public class FinalizarAluguelViewModel : FormAluguelViewModel
{
    public List<TaxaServico> Taxas { get; set; }
    public List<int> TaxasId { get; set; }
    public decimal? ValorFinal { get; set; }
    public int KmFinal {  get; set; }
    public Cliente Cliente { get; set; }
    public Condutor Condutor { get; set; }
    public Combustivel Combustivel{ get; set; }
    public Veiculo Veiculo { get; set; }
    public Aluguel Aluguel { get; set; }
    public Plano Plano { get; set; }
    public GrupoVeiculos Grupo { get; set; }
}
public class DetalhesAluguelViewModel : FormAluguelViewModel
{
    public Cliente Cliente { get; set; }
    public Condutor Condutor { get; set; }
    public Veiculo Veiculo { get; set; }
    public Plano Plano { get; set; }
    public GrupoVeiculos Grupo { get; set; }
    public List<TaxaServico> Taxas { get; set; }
}

public class PrefinalizarAluguelViewModel : FormAluguelViewModel
{
    public int KmFinal {  set; get; }
    public decimal? ValorFinal {  set; get; }
    public Aluguel Aluguel { get; set; }
    public Combustivel Combustivel {  get; set; }
    public EnumMarcadorCombustivel QuantiaCombustivel {  get; set; }
}
