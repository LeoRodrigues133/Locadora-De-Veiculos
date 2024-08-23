using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddcolunanomeGrupos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBVeiculos_TBGrupo_GrupoVeiculos_Name",
                table: "TBVeiculos");

            migrationBuilder.DropIndex(
                name: "IX_TBVeiculos_GrupoVeiculos_Name",
                table: "TBVeiculos");

            migrationBuilder.DropColumn(
                name: "GrupoVeiculos_Name",
                table: "TBVeiculos");

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculos_GrupoVeiculosId",
                table: "TBVeiculos",
                column: "GrupoVeiculosId");

            migrationBuilder.AddForeignKey(
                name: "Grupo_Name",
                table: "TBVeiculos",
                column: "GrupoVeiculosId",
                principalTable: "TBGrupo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Grupo_Name",
                table: "TBVeiculos");

            migrationBuilder.DropIndex(
                name: "IX_TBVeiculos_GrupoVeiculosId",
                table: "TBVeiculos");

            migrationBuilder.AddColumn<int>(
                name: "GrupoVeiculos_Name",
                table: "TBVeiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculos_GrupoVeiculos_Name",
                table: "TBVeiculos",
                column: "GrupoVeiculos_Name");

            migrationBuilder.AddForeignKey(
                name: "FK_TBVeiculos_TBGrupo_GrupoVeiculos_Name",
                table: "TBVeiculos",
                column: "GrupoVeiculos_Name",
                principalTable: "TBGrupo",
                principalColumn: "Id");
        }
    }
}
