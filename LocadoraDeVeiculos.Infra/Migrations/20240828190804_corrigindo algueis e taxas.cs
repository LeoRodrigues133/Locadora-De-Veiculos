using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class corrigindoalgueisetaxas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAluguel_TBTaxasEServicos_TaxaServicoId1",
                table: "TBAluguel");

            migrationBuilder.DropIndex(
                name: "IX_TBAluguel_TaxaServicoId1",
                table: "TBAluguel");

            migrationBuilder.DropColumn(
                name: "TaxaServicoId1",
                table: "TBAluguel");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_TaxaServicoId",
                table: "TBAluguel",
                column: "TaxaServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAluguel_TBTaxasEServicos_TaxaServicoId",
                table: "TBAluguel",
                column: "TaxaServicoId",
                principalTable: "TBTaxasEServicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAluguel_TBTaxasEServicos_TaxaServicoId",
                table: "TBAluguel");

            migrationBuilder.DropIndex(
                name: "IX_TBAluguel_TaxaServicoId",
                table: "TBAluguel");

            migrationBuilder.AddColumn<int>(
                name: "TaxaServicoId1",
                table: "TBAluguel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_TaxaServicoId1",
                table: "TBAluguel",
                column: "TaxaServicoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAluguel_TBTaxasEServicos_TaxaServicoId1",
                table: "TBAluguel",
                column: "TaxaServicoId1",
                principalTable: "TBTaxasEServicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
