using System.Reflection;
using Microsoft.AspNetCore.Identity;
using LocadoraDeVeiculos.WebApp.Mapping;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloAlugueis;
using LocadoraDeVeiculos.Infra.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloUsuario;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis;
using Microsoft.AspNetCore.Authentication.Cookies;
using LocadoraDeVeiculos.WebApp.Mapping.Resolvers;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloAlugueis.ModuloTaxas;
using LocadoraDeVeiculos.Infra.ModuloPessoas.ModuloClientes;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloClientes;
using LocadoraDeVeiculos.Infra.ModuloPessoas.ModuloCondutores;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloAlugueis;
using LocadoraDeVeiculos.Infra.ModuloPessoas.ModuloFuncionarios;
using LocadoraDeVeiculos.Infra.ModuloVeiculos.ModuloCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloCondutores;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Injeção de dependencias

            builder.Services.AddDbContext<LocadoraDbContext>();

            builder.Services.AddScoped<IRepositorioPlano, RepositorioPlanoEmOrm>();
            builder.Services.AddScoped<IRepositorioAluguel, RepositorioAluguelEmOrm>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEmOrm>();
            builder.Services.AddScoped<IRepositorioVeiculo, RepositorioVeiculosEmOrm>();
            builder.Services.AddScoped<IRepositorioTaxaEServicos, RepositorioTaxasEmOrm>();
            builder.Services.AddScoped<IRepositorioCondutor, RepositorioCondutoresEmOrm>();
            builder.Services.AddScoped<IRepositorioCombustivel, RepositorioCombustivelEmOrm>();
            builder.Services.AddScoped<IRepositorioFuncionario, RepositorioFuncionarioEmOrm>();
            builder.Services.AddScoped<IRepositorioGrupoVeiculos, RepositorioGrupoVeiculosOrm>();

            builder.Services.AddScoped<Resolver>();
            builder.Services.AddScoped<TaxasService>();
            builder.Services.AddScoped<PlanoService>();
            builder.Services.AddScoped<AluguelService>();
            builder.Services.AddScoped<ClienteService>();
            builder.Services.AddScoped<VeiculoService>();
            builder.Services.AddScoped<CondutorService>();
            //builder.Services.AddScoped<FotoValueResolver>();
            builder.Services.AddScoped<CombustivelService>();
            builder.Services.AddScoped<FuncionarioService>();
            builder.Services.AddScoped<GrupoVeiculosService>();
            builder.Services.AddScoped<EmpresaIdValueResolver>();

            builder.Services.AddAutoMapper(config =>
            {
                config.AddMaps(Assembly.GetExecutingAssembly());
            });


            builder.Services.AddScoped<AuthService>();

            builder.Services.AddIdentity<Usuario, Perfil>()
                .AddEntityFrameworkStores<LocadoraDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "AspNetCore.Cookies";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                    options.SlidingExpiration = true;
                });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
                options.AccessDeniedPath = "/Auth/AcessoNegado";
            });

            #endregion

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
