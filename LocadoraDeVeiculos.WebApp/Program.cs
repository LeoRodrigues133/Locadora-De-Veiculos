using System.Reflection;
using LocadoraDeVeiculos.WebApp.Mapping;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloAlugueis;
using LocadoraDeVeiculos.Infra.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis;
using LocadoraDeVeiculos.Infra.ModuloPessoas.ModuloClientes;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloClientes;
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
            builder.Services.AddScoped<IRepositorioVeiculo, RepositorioVeiculosEmOrm>();
            builder.Services.AddScoped<IRepositorioGrupoVeiculos, RepositorioGrupoVeiculosOrm>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEmOrm>();

            builder.Services.AddScoped<PlanoService>();
            builder.Services.AddScoped<ClienteService>();
            builder.Services.AddScoped<VeiculoService>();
            builder.Services.AddScoped<GrupoVeiculosService>();
            builder.Services.AddScoped<Resolver>();

            builder.Services.AddAutoMapper(config =>
            {
                config.AddMaps(Assembly.GetExecutingAssembly());
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
