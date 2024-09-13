using FluentResults;
using Microsoft.AspNetCore.Identity;
using LocadoraDeVeiculos.Dominio.ModuloAuth;
using LocadoraDeVeiculos.Dominio.ModuloPessoas;
using LocadoraDeVeiculos.Dominio.ModuloUsuario;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloFuncionario;

namespace LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;

public class FuncionarioService
{
    private readonly RoleManager<Perfil> _roleManager;
    private readonly UserManager<Usuario> _userManager;
    private readonly IRepositorioFuncionario _repositorioFuncionario;

    public FuncionarioService(
        IRepositorioFuncionario repositorioFuncionario,
        UserManager<Usuario> userManager,
        RoleManager<Perfil> roleManager
    )
    {
        _repositorioFuncionario = repositorioFuncionario;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<Result<Funcionario>> Cadastrar(
        Funcionario funcionario, string nomeUsuario, string senha)
    {
        var usuario = new Usuario()
        {
            UserName = nomeUsuario,
            Email = funcionario.Email
        };

        var resultadoCriacaoUsuario = await _userManager.CreateAsync(usuario, senha);

        if (!resultadoCriacaoUsuario.Succeeded)
            return Result.Fail(resultadoCriacaoUsuario.Errors.Select(e => e.Description));

        var perfilStr = TipoUsuarioEnum.Funcionario.ToString();

        var resultadoBuscaPerfil = await _roleManager.FindByNameAsync(perfilStr);

        if (resultadoBuscaPerfil is null)
        {
            var perfil = new Perfil()
            {
                Name = perfilStr,
                NormalizedName = perfilStr.ToUpperInvariant(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            await _roleManager.CreateAsync(perfil);
        }

        await _userManager.AddToRoleAsync(usuario, perfilStr);

        funcionario.UsuarioId = usuario.Id;

        _repositorioFuncionario.Cadastrar(funcionario);

        return Result.Ok(funcionario);
    }

    public Result<Funcionario> Editar(Funcionario funcionario)
    {
        //var erros = funcionario.Validar();

        //if (erros.Count > 0)
        //    return Result.Fail(erros);

        _repositorioFuncionario.Editar(funcionario);

        return Result.Ok(funcionario);
    }

    public async Task<Result> Excluir(int funcionarioId)
    {
        var funcionario = _repositorioFuncionario.SelecionarIdPorEmpresa(f => f.Id == funcionarioId);

        if (funcionario is null)
            return Result.Fail("O funcionário não foi encontrado!");

        var usuario = await _userManager.FindByIdAsync(funcionario.UsuarioId.ToString());

        if (usuario is null)
            return Result.Fail("O usuário não foi encontrado!");

        var resultadoExclusao = await _userManager.DeleteAsync(usuario);

        if (!resultadoExclusao.Succeeded)
            return Result.Fail("Não foi possível excluir o funcionário!");

        _repositorioFuncionario.Excluir(funcionario);

        return Result.Ok();
    }

    public Result<Funcionario?> SelecionarPorId(int funcionarioId)
    {
        var funcionario = _repositorioFuncionario.SelecionarIdPorEmpresa(f => f.Id == funcionarioId);

        return Result.Ok(funcionario);
    }

    public Result<List<Funcionario>> SelecionarFuncionariosDaEmpresa(int id)
    {
        var funcionarios = _repositorioFuncionario.Filtrar(x => x.EmpresaId == id);

        return Result.Ok(funcionarios);
    }

}