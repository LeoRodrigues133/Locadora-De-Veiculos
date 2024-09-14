using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Aplicacao.Services;

public class VeiculoService
{
    readonly IRepositorioVeiculo _repositorioVeiculo;
    readonly IRepositorioGrupoVeiculos _repositorioGrupo;
    readonly IRepositorioCombustivel _repositorioCombustivel;

    public VeiculoService(IRepositorioVeiculo repositorioVeiculo, IRepositorioGrupoVeiculos repositorioGrupo, IRepositorioCombustivel repositorioCombustivel)
    {
        _repositorioVeiculo = repositorioVeiculo;
        _repositorioGrupo = repositorioGrupo;
        _repositorioCombustivel = repositorioCombustivel;
    }

    public Result<Veiculo> Cadastrar(Veiculo veiculo)
    {


        var id = veiculo.GrupoVeiculosId;

        var grupo = _repositorioGrupo.SelecionarPorId(id);

        veiculo.GrupoVeiculos = grupo;

        _repositorioVeiculo.Cadastrar(veiculo);

        return Result.Ok(veiculo);
    }

    public Result<Veiculo> Excluir(int id)
    {
        var veiculo = _repositorioVeiculo.SelecionarPorId(id);

        if (veiculo is null)
            return Result.Fail("O Veículo não foi encontrado!");

        _repositorioVeiculo.Excluir(veiculo);

        return Result.Ok();
    }

    public Result<Veiculo> Editar(Veiculo veiculoEditado)
    {
        var veiculoSelecionado = _repositorioVeiculo.SelecionarPorId(veiculoEditado.Id);

        if (veiculoSelecionado is null)
            return Result.Fail("O Veículo não foi encontrado!");

        #region Erros
        if (veiculoSelecionado.Ano < 1900 || veiculoSelecionado.Ano > DateTime.Now.Year)
            return Result.Fail("Ano do veículo inválido.");

        if (string.IsNullOrWhiteSpace(veiculoSelecionado.Placa) || veiculoSelecionado.Placa.Length > 10)
            return Result.Fail("Placa inválida.");

        if (string.IsNullOrWhiteSpace(veiculoSelecionado.Modelo) || veiculoSelecionado.Modelo.Length > 20)
            return Result.Fail("Modelo inválido.");

        if (veiculoSelecionado.Quilometragem < 0)
            return Result.Fail("Quilometragem não pode ser negativa.");

        if (veiculoSelecionado.GrupoVeiculos is null)
            return Result.Fail("O veículo deve ser registrado em um grupo.");

        if (veiculoSelecionado.CapacidadeTanqueDeCombustivel <= 0)
            return Result.Fail("Capacidade do tanque de combustível deve ser maior que zero.");
        #endregion

        #region Edit
        veiculoSelecionado.Cor = veiculoEditado.Cor;
        veiculoSelecionado.Marca = veiculoEditado.Marca;
        veiculoSelecionado.Combustivel= veiculoEditado.Combustivel;
        veiculoSelecionado.GrupoVeiculosId = veiculoEditado.GrupoVeiculosId;
        veiculoSelecionado.Ano = veiculoEditado.Ano;
        veiculoSelecionado.Placa = veiculoEditado.Placa;
        veiculoSelecionado.Modelo = veiculoEditado.Modelo;
        veiculoSelecionado.Alugado = veiculoEditado.Alugado;
        veiculoSelecionado.Quilometragem = veiculoEditado.Quilometragem;
        veiculoSelecionado.CapacidadeTanqueDeCombustivel = veiculoEditado.CapacidadeTanqueDeCombustivel;
        #endregion|

        _repositorioVeiculo.Editar(veiculoSelecionado);

        return Result.Ok(veiculoSelecionado);
    }

    public Result<List<Veiculo>> SelecionarTodos(int id)
    {
        var veiculos = _repositorioVeiculo.Filtrar(x => x.EmpresaId == id);

        return Result.Ok(veiculos);
    }

    public Result<Veiculo> SelecionarId(int Id)
    {
        var veiculo = _repositorioVeiculo.SelecionarPorId(Id);

        if (veiculo is null)
            return Result.Fail("O Veículo não foi encontrado!");

        return Result.Ok(veiculo);
    }

}
