using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;

namespace LocadoraDeVeiculos.Dominio;

public class Aluguel : EntidadeBase
{
    public Aluguel(
        Plano plano, 
        Seguro seguro, 
        Cliente cliente, 
        Veiculo veiculo, 
        Condutor condutor, 
        DateTime dataLocacao,
        DateTime dateDevolucao
        )
    {
        Plano = plano;
        Seguro = seguro;
        Cliente = cliente;
        Veiculo = veiculo;
        Condutor = condutor;
        DataLocacao = dataLocacao;
        DateDevolucao = dateDevolucao;
    }

    public Condutor Condutor {  get; set; }
    public Veiculo Veiculo { get; set; }
    public Cliente Cliente { get; set; }
    public Plano Plano { get; set; }
    public Seguro Seguro { get; set; }
    public DateTime DataLocacao { get; set; }
    public DateTime DateDevolucao {  get; set; }

}