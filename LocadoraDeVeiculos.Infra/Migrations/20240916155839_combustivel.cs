using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class combustivel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "TBCombustivel");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "TBCombustivel");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "TBCombustivel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ValorAlcool",
                table: "TBCombustivel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorDiesel",
                table: "TBCombustivel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorGas",
                table: "TBCombustivel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorGasolina",
                table: "TBCombustivel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "TBCombustivel");

            migrationBuilder.DropColumn(
                name: "ValorAlcool",
                table: "TBCombustivel");

            migrationBuilder.DropColumn(
                name: "ValorDiesel",
                table: "TBCombustivel");

            migrationBuilder.DropColumn(
                name: "ValorGas",
                table: "TBCombustivel");

            migrationBuilder.DropColumn(
                name: "ValorGasolina",
                table: "TBCombustivel");

            migrationBuilder.AddColumn<int>(
                name: "Nome",
                table: "TBCombustivel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "TBCombustivel",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
