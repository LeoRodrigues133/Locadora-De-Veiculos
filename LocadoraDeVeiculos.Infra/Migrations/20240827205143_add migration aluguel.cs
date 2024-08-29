using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationaluguel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AluguelId",
                table: "TBTaxasEServicos",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "TBAluguel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entrada = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    TaxaServicoId = table.Column<int>(type: "int", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateDevolucaoPrevista = table.Column<DateTime>(type: "datetime", nullable: true),
                    PlanoId = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    GrupoId = table.Column<int>(type: "int", nullable: false),
                    CondutorId = table.Column<int>(type: "int", nullable: false),
                    SeguroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAluguel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAluguel_Seguro_SeguroId",
                        column: x => x.SeguroId,
                        principalTable: "Seguro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCondutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBGrupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "TBGrupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBPlano_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "TBPlano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBTaxasEServicos_TaxaServicoId",
                        column: x => x.TaxaServicoId,
                        principalTable: "TBTaxasEServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBVeiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TBVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxasEServicos_AluguelId",
                table: "TBTaxasEServicos",
                column: "AluguelId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_ClienteId",
                table: "TBAluguel",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_CondutorId",
                table: "TBAluguel",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_GrupoId",
                table: "TBAluguel",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_PlanoId",
                table: "TBAluguel",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_SeguroId",
                table: "TBAluguel",
                column: "SeguroId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_TaxaServicoId",
                table: "TBAluguel",
                column: "TaxaServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_VeiculoId",
                table: "TBAluguel",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBTaxasEServicos_TBAluguel_AluguelId",
                table: "TBTaxasEServicos",
                column: "AluguelId",
                principalTable: "TBAluguel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBTaxasEServicos_TBAluguel_AluguelId",
                table: "TBTaxasEServicos");

            migrationBuilder.DropTable(
                name: "TBAluguel");

            migrationBuilder.DropTable(
                name: "Seguro");

            migrationBuilder.DropIndex(
                name: "IX_TBTaxasEServicos_AluguelId",
                table: "TBTaxasEServicos");

            migrationBuilder.DropColumn(
                name: "AluguelId",
                table: "TBTaxasEServicos");
        }
    }
}
