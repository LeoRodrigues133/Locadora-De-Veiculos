using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio;

public class Veiculo : EntidadeBase
{
    public Veiculo(
        Cor cor, 
        Marca marca, 
        TipoCnh tipoCnh, 
        Combustivel combustivel, 
        DateTime ano, 
        string placa, 
        string modelo, 
        int quilometragem, 
        int capacidadeTanqueDeCombustivel)
    {
        Cor = cor;
        Marca = marca;
        TipoCnh = tipoCnh;
        Combustivel = combustivel;
        Ano = ano;
        Placa = placa;
        Modelo = modelo;
        Quilometragem = quilometragem;
        CapacidadeTanqueDeCombustivel = capacidadeTanqueDeCombustivel;
    }

    public Cor Cor { get; set; }
    public Marca Marca { get; set; }
    public TipoCnh TipoCnh { get; set; }
    public Combustivel Combustivel { get; set; }
    public DateTime Ano { get; set; }
    public string Placa {  get; set; }
    public string Modelo {  get; set; }
    public int Quilometragem {  get; set; }
    public int CapacidadeTanqueDeCombustivel { get; set; }

}