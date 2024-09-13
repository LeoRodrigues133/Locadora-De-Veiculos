using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculos;

public class Veiculo : EntidadeBase
{
    public Veiculo()
    {
        
    }
    //public byte[] Foto { get; set; }
    public bool Alugado { get; set; }
    public Cor Cor { get; set; }
    public Marca Marca { get; set; }
    public EnumCombustivel Combustivel { get; set; }
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
        EnumCombustivel combustivel,
        int grupoVeiculosId,
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
        Ano = ano;
        Placa = placa;
        Modelo = modelo;
        Alugado = alugado;
        Quilometragem = quilometragem;
        CapacidadeTanqueDeCombustivel = capacidadeTanqueDeCombustivel;
    }

    public override List<string> Validar()
    {
        var erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Placa))
            erros.Add("A placa é obrigatória.");
        else if (Placa.Length < 7)
            erros.Add("A placa deve ter 7 caracteres.");

        if (string.IsNullOrWhiteSpace(Modelo))
            erros.Add("O modelo é obrigatório.");
        else if (Modelo.Length < 2)
            erros.Add("O modelo deve ter pelo menos 2 caracteres.");

        // Validação do Ano
        if (Ano <= 2000 || Ano > DateTime.Now.Year + 1) 
            erros.Add("O ano do veículo é inválido.");

        if (Quilometragem < 0)
            erros.Add("A quilometragem não pode ser negativa.");

        if (CapacidadeTanqueDeCombustivel <= 0)
            erros.Add("A capacidade do tanque de combustível deve ser maior que zero.");

        if (GrupoVeiculosId <= 0)
            erros.Add("O grupo de veículos é obrigatório.");

        if (Marca == null)
            erros.Add("A marca é obrigatória.");

        if (Cor == null)
            erros.Add("A cor é obrigatória.");

        if (!Enum.IsDefined(typeof(EnumCombustivel), Combustivel))
            erros.Add("O tipo de combustível é inválido.");

        return erros;
    }

}