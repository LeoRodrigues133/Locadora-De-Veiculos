using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculos;

public class Veiculo : EntidadeBase
{
    public bool Alugado { get; set; }
    public Cor Cor { get; set; }
    public Marca Marca { get; set; }
    public CategoriaVeiculo CategoriaVeiculo { get; set; }
    public Combustivel Combustivel { get; set; }
    public GrupoVeiculos? GrupoVeiculos { get; set; }
    public int GrupoVeiculosId { get; set; }
    public int Ano { get; set; }
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public int Quilometragem { get; set; }
    public int CapacidadeTanqueDeCombustivel { get; set; }

    public Veiculo(
        Cor cor,
        Marca marca,
        Combustivel combustivel,
        int grupoVeiculosId,
        CategoriaVeiculo categoriaVeiculo,
        int ano,
        bool alugado,
        string placa,
        string modelo,
        int quilometragem,
        int capacidadeTanqueDeCombustivel)
    {
        Cor = cor;
        Marca = marca;
        Combustivel = combustivel;
        GrupoVeiculosId = grupoVeiculosId;
        CategoriaVeiculo = categoriaVeiculo;
        Ano = ano;
        Placa = placa;
        Modelo = modelo;
        Alugado = alugado;
        Quilometragem = quilometragem;
        CapacidadeTanqueDeCombustivel = capacidadeTanqueDeCombustivel;
    }

}