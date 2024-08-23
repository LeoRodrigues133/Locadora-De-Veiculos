using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBGrupo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBPlano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorDiaria = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    PrecoKM = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ValorExtrapolado = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    KmDisponivel = table.Column<int>(type: "int", nullable: true),
                    GrupoVeiculosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlano", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlano_TBGrupo_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TBGrupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alugado = table.Column<bool>(type: "bit", nullable: false),
                    Cor = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<int>(type: "int", nullable: false),
                    Combustivel = table.Column<int>(type: "int", nullable: false),
                    GrupoVeiculosId = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "Varchar(10)", nullable: false),
                    Modelo = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Quilometragem = table.Column<int>(type: "int", nullable: false),
                    CapacidadeTanqueDeCombustivel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculos_TBGrupo_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TBGrupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPlano_GrupoVeiculosId",
                table: "TBPlano",
                column: "GrupoVeiculosId");

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculos_GrupoVeiculosId",
                table: "TBVeiculos",
                column: "GrupoVeiculosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlano");

            migrationBuilder.DropTable(
                name: "TBVeiculos");

            migrationBuilder.DropTable(
                name: "TBGrupo");
        }
    }
}
