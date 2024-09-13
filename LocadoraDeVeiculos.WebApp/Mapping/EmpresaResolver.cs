using AutoMapper;
using System.Security.Authentication;
using LocadoraDeVeiculos.Aplicacao.Services;

namespace LocadoraDeVeiculos.WebApp.Mapping.Resolvers;

public class EmpresaIdValueResolver : IValueResolver<object, object, int>
{
    private readonly AuthService _authService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EmpresaIdValueResolver(AuthService authService, IHttpContextAccessor httpContextAccessor)
    {
        _authService = authService;
        _httpContextAccessor = httpContextAccessor;
    }

    public int Resolve(object source, object destination, int destMember, ResolutionContext context)
    {
        var usuarioClaim = _httpContextAccessor.HttpContext?.User;

        var empresaId = _authService.ObterIdEmpresaAsync(usuarioClaim!).Result;

        if (empresaId is null)
            throw new AuthenticationException("Não foi possível obter o ID da empresa requisitada!");

        return empresaId.Value;
    }
}