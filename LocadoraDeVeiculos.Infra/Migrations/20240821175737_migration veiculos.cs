using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class migrationveiculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alugado = table.Column<bool>(type: "bit", nullable: false),
                    Cor = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<int>(type: "int", nullable: false),
                    CategoriaVeiculo = table.Column<int>(type: "int", nullable: false),
                    Combustivel = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "Varchar(10)", nullable: false),
                    Modelo = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Quilometragem = table.Column<int>(type: "int", nullable: false),
                    CapacidadeTanqueDeCombustivel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBVeiculos");
        }
    }
}
