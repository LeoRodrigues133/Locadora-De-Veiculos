using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddcolunaIdAluguelemTaxas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAluguel_Seguro_SeguroId",
                table: "TBAluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_TBAluguel_TBTaxasEServicos_TaxaServicoId",
                table: "TBAluguel");

            migrationBuilder.DropTable(
                name: "Seguro");

            migrationBuilder.DropIndex(
                name: "IX_TBAluguel_TaxaServicoId",
                table: "TBAluguel");

            migrationBuilder.RenameColumn(
                name: "SeguroId",
                table: "TBAluguel",
                newName: "TaxaServicoId1");

            migrationBuilder.RenameIndex(
                name: "IX_TBAluguel_SeguroId",
                table: "TBAluguel",
                newName: "IX_TBAluguel_TaxaServicoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAluguel_TBTaxasEServicos_TaxaServicoId1",
                table: "TBAluguel",
                column: "TaxaServicoId1",
                principalTable: "TBTaxasEServicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAluguel_TBTaxasEServicos_TaxaServicoId1",
                table: "TBAluguel");

            migrationBuilder.RenameColumn(
                name: "TaxaServicoId1",
                table: "TBAluguel",
                newName: "SeguroId");

            migrationBuilder.RenameIndex(
                name: "IX_TBAluguel_TaxaServicoId1",
                table: "TBAluguel",
                newName: "IX_TBAluguel_SeguroId");

            migrationBuilder.CreateTable(
                name: "Seguro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguro", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_TaxaServicoId",
                table: "TBAluguel",
                column: "TaxaServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAluguel_Seguro_SeguroId",
                table: "TBAluguel",
                column: "SeguroId",
                principalTable: "Seguro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBAluguel_TBTaxasEServicos_TaxaServicoId",
                table: "TBAluguel",
                column: "TaxaServicoId",
                principalTable: "TBTaxasEServicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
