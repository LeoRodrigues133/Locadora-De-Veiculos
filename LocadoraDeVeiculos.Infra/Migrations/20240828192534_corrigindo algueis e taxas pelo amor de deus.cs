using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class corrigindoalgueisetaxaspeloamordedeus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAluguel_TBTaxasEServicos_TaxaServicoId",
                table: "TBAluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_TBTaxasEServicos_TBAluguel_AluguelId",
                table: "TBTaxasEServicos");

            migrationBuilder.DropIndex(
                name: "IX_TBTaxasEServicos_AluguelId",
                table: "TBTaxasEServicos");

            migrationBuilder.DropIndex(
                name: "IX_TBAluguel_TaxaServicoId",
                table: "TBAluguel");

            migrationBuilder.DropColumn(
                name: "AluguelId",
                table: "TBTaxasEServicos");

            migrationBuilder.DropColumn(
                name: "TaxaServicoId",
                table: "TBAluguel");

            migrationBuilder.CreateTable(
                name: "TBAluguelTaxa",
                columns: table => new
                {
                    AlugueisId = table.Column<int>(type: "int", nullable: false),
                    TaxasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAluguelTaxa", x => new { x.AlugueisId, x.TaxasId });
                    table.ForeignKey(
                        name: "FK_TBAluguelTaxa_TBAluguel_AlugueisId",
                        column: x => x.AlugueisId,
                        principalTable: "TBAluguel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBAluguelTaxa_TBTaxasEServicos_TaxasId",
                        column: x => x.TaxasId,
                        principalTable: "TBTaxasEServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguelTaxa_TaxasId",
                table: "TBAluguelTaxa",
                column: "TaxasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAluguelTaxa");

            migrationBuilder.AddColumn<int>(
                name: "AluguelId",
                table: "TBTaxasEServicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxaServicoId",
                table: "TBAluguel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxasEServicos_AluguelId",
                table: "TBTaxasEServicos",
                column: "AluguelId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TBTaxasEServicos_TBAluguel_AluguelId",
                table: "TBTaxasEServicos",
                column: "AluguelId",
                principalTable: "TBAluguel",
                principalColumn: "Id");
        }
    }
}
