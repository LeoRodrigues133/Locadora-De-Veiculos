using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculos;

public class Veiculo : EntidadeBase
{
    public Veiculo(
        bool alugado,
        Cor cor,
        Marca marca,
        CategoriaVeiculo categoriaVeiculo,
        Combustivel combustivel,
        int ano,
        string placa,
        string modelo,
        int quilometragem,
        int capacidadeTanqueDeCombustivel)
    {
        Alugado = alugado;
        Cor = cor;
        Marca = marca;
        CategoriaVeiculo = categoriaVeiculo;
        Combustivel = combustivel;
        Ano = ano;
        Placa = placa;
        Modelo = modelo;
        Quilometragem = quilometragem;
        CapacidadeTanqueDeCombustivel = capacidadeTanqueDeCombustivel;
    }

    public bool Alugado { get; set; }
    public Cor Cor { get; set; }
    public Marca Marca { get; set; }
    public CategoriaVeiculo CategoriaVeiculo { get; set; }
    public Combustivel Combustivel { get; set; }
    public int Ano { get; set; }
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public int Quilometragem { get; set; }
    public int CapacidadeTanqueDeCombustivel { get; set; }

}