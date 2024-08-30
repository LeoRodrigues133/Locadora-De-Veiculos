using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocadoraDeVeiculos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FullmigrationwData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RG = table.Column<string>(type: "varchar(20)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(200)", nullable: false),
                    TipoPerfil = table.Column<bool>(type: "bit", nullable: false),
                    CPF = table.Column<string>(type: "varchar(14)", nullable: true),
                    CNPJ = table.Column<string>(type: "varchar(18)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCliente", x => x.Id);
                });

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
                name: "TBTaxasEServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TipoDeCobranca = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTaxasEServicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBCondutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNH = table.Column<string>(type: "varchar(14)", nullable: false),
                    ValidadeCNH = table.Column<DateTime>(type: "date", nullable: false),
                    ClienteCondutor = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(17)", nullable: true),
                    CPF = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCondutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCondutor_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBPlano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPlano = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "TBAluguel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entrada = table.Column<int>(type: "int", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateDevolucaoPrevista = table.Column<DateTime>(type: "datetime", nullable: true),
                    GrupoId = table.Column<int>(type: "int", nullable: false),
                    PlanoId = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    CondutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAluguel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCondutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBGrupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "TBGrupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBPlano_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "TBPlano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBVeiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TBVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "TBCliente",
                columns: new[] { "Id", "CNPJ", "CPF", "Email", "Endereco", "Nome", "RG", "Telefone", "TipoPerfil" },
                values: new object[,]
                {
                    { 1, null, "123.456.789-00", "joao.silva@example.com", "Rua A, 123", "João Silva", "1.456.789", "(11) 91234-5678", true },
                    { 2, null, "987.654.321-00", "maria.oliveira@example.com", "Rua B, 456", "Maria Oliveira", "9.654.321", "(11) 99876-5432", true },
                    { 3, null, "567.891.234-56", "carlos.santos@example.com", "Rua E, 202", "Carlos Santos", "7.891.234", "(11) 91234-0000", true },
                    { 4, null, "101.010.101-01", "ana.paula@example.com", "Rua G, 404", "Ana Paula", "1.010.101", "(11) 91234-5679", true },
                    { 5, null, "111.111.111-11", "pedro.almeida@example.com", "Rua H, 505", "Pedro Almeida", "1.111.111", "(11) 97777-1111", true },
                    { 6, "00.111.222/0001-33", null, "comercial@abc.com", "Rua F, 303", "Comercial ABC", "5.448.489", "(11) 98888-7777", false },
                    { 7, "22.333.444/0001-55", null, "contato@lmn.com", "Rua J, 707", "Construtora LMN", "4.894.984", "(11) 94444-5555", false },
                    { 8, "11.222.333/0001-44", null, "contato@tecnologiaxyz.com", "Avenida I, 606", "Tecnologia XYZ", "5.654.321", "(11) 92222-4444", false },
                    { 9, "12.345.678/0001-99", null, "contato@empresax.com", "Avenida C, 789", "Empresa X", "1.156.854", "(11) 93456-7890", false },
                    { 10, "98.765.432/0001-88", null, "contato@empresay.com", "Avenida D, 101", "Empresa Y", "4.984.888", "(11) 97654-3210", false }
                });

            migrationBuilder.InsertData(
                table: "TBGrupo",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "SUV" },
                    { 2, "Utilitário" },
                    { 3, "Sedan" },
                    { 4, "Hatchback" },
                    { 5, "Coupe" },
                    { 6, "Conversível" },
                    { 7, "Pickup" },
                    { 8, "Minivan" },
                    { 9, "Esportivo" },
                    { 10, "Elétrico" }
                });

            migrationBuilder.InsertData(
                table: "TBTaxasEServicos",
                columns: new[] { "Id", "Nome", "TipoDeCobranca", "Valor" },
                values: new object[,]
                {
                    { 1, "Taxa de Limpeza", true, 50m },
                    { 2, "Taxa de Seguro", true, 150m },
                    { 3, "Taxa de Atendimento Noturno", true, 80m },
                    { 4, "Taxa de Entrega Especial", true, 120m },
                    { 5, "Taxa de Administração", true, 200m },
                    { 6, "Taxa de Retorno Antecipado", true, 60m },
                    { 7, "Taxa de Cancelamento", true, 100m },
                    { 8, "Taxa de Reservas Especiais", true, 75m },
                    { 9, "Taxa de Condução Adicional", true, 40m },
                    { 10, "Taxa de Expedição de Documentos", true, 90m },
                    { 11, "Taxa de GPS", false, 15m },
                    { 12, "Taxa de Assento Infantil", false, 20m },
                    { 13, "Taxa de Adicional de Condutor", false, 25m },
                    { 14, "Taxa de Pedágio", false, 10m },
                    { 15, "Taxa de Combustível Extra", false, 30m },
                    { 16, "Taxa de Equipamento de Segurança", false, 35m },
                    { 17, "Taxa de Seguro Adicional", false, 40m },
                    { 18, "Taxa de Kit de Primeiros Socorros", false, 18m },
                    { 19, "Taxa de Seguro contra Danos", false, 50m },
                    { 20, "Taxa de Trajeto Internacional", false, 60m }
                });

            migrationBuilder.InsertData(
                table: "TBCondutor",
                columns: new[] { "Id", "CNH", "CPF", "ClienteCondutor", "ClienteId", "Email", "Nome", "Telefone", "ValidadeCNH" },
                values: new object[,]
                {
                    { 1, "CNH12345678", "123.456.789-00", true, 1, "joao.silva@example.com", "João Silva", "(11) 91234-5678", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "CNH23456789", "987.654.321-00", true, 2, "maria.oliveira@example.com", "Maria Oliveira", "(11) 99876-5432", new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "CNH34567890", "567.891.234-56", true, 5, "carlos.santos@example.com", "Carlos Santos", "(11) 91234-0000", new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "CNH45678901", "101.010.101-01", true, 7, "ana.paula@example.com", "Ana Paula", "(11) 91234-5679", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "CNH56789012", "111.111.111-11", true, 8, "pedro.almeida@example.com", "Pedro Almeida", "(11) 97777-1111", new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "CNH67890123", null, false, 6, "condutor1@abc.com", "Condutor Comercial ABC 1", "(11) 98888-7777", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "CNH78901234", null, false, 6, "condutor2@abc.com", "Condutor Comercial ABC 2", "(11) 98888-7778", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "CNH89012345", null, false, 6, "condutor3@abc.com", "Condutor Comercial ABC 3", "(11) 98888-7779", new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "CNH90123456", null, false, 10, "condutor1@lmn.com", "Condutor Construtora LMN 1", "(11) 94444-5555", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "CNH01234567", null, false, 10, "condutor2@lmn.com", "Condutor Construtora LMN 2", "(11) 94444-5556", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "CNH12345678", null, false, 10, "condutor3@lmn.com", "Condutor Construtora LMN 3", "(11) 94444-5557", new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "CNH23456789", null, false, 9, "condutor1@tecnologiaxyz.com", "Condutor Tecnologia XYZ 1", "(11) 92222-4444", new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "CNH34567890", null, false, 9, "condutor2@tecnologiaxyz.com", "Condutor Tecnologia XYZ 2", "(11) 92222-4445", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "CNH45678901", null, false, 9, "condutor3@tecnologiaxyz.com", "Condutor Tecnologia XYZ 3", "(11) 92222-4446", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TBPlano",
                columns: new[] { "Id", "GrupoVeiculosId", "KmDisponivel", "PrecoKM", "TipoPlano", "ValorDiaria", "ValorExtrapolado" },
                values: new object[,]
                {
                    { 1, 1, 300, null, 0, 100m, 20m },
                    { 2, 2, 500, 10m, 1, 150m, 30m },
                    { 3, 3, 700, 15m, 2, 200m, 40m },
                    { 4, 4, 1000, null, 0, 250m, 50m },
                    { 5, 5, 400, 12m, 1, 120m, 25m },
                    { 6, 6, 600, 18m, 2, 180m, 35m },
                    { 7, 7, 800, null, 0, 230m, 45m },
                    { 8, 8, 1100, 20m, 1, 270m, 55m },
                    { 9, 9, 350, 25m, 2, 130m, 30m },
                    { 10, 10, 650, null, 0, 190m, 40m }
                });

            migrationBuilder.InsertData(
                table: "TBVeiculos",
                columns: new[] { "Id", "Alugado", "Ano", "CapacidadeTanqueDeCombustivel", "Combustivel", "Cor", "GrupoVeiculosId", "Marca", "Modelo", "Placa", "Quilometragem" },
                values: new object[,]
                {
                    { 1, false, 2022, 50, 0, 0, 1, 0, "Gol", "ABC1D23", 10000 },
                    { 2, false, 2021, 55, 4, 1, 1, 0, "Virtus", "DEF4G56", 5000 },
                    { 3, true, 2020, 60, 2, 2, 2, 0, "Tiguan", "GHI7J89", 25000 },
                    { 4, false, 2019, 50, 1, 4, 2, 0, "Polo", "JKL0M12", 30000 },
                    { 5, false, 2023, 48, 4, 5, 3, 1, "Uno", "MNO3P45", 5000 },
                    { 6, false, 2022, 45, 0, 3, 3, 1, "Argo", "PQR6S78", 10000 },
                    { 7, true, 2021, 60, 1, 1, 4, 1, "Toro", "STU9V01", 20000 },
                    { 8, false, 2020, 70, 2, 0, 4, 1, "Freemont", "VWX2Y34", 35000 },
                    { 9, false, 2022, 45, 0, 4, 5, 2, "Onix", "XYZ5Z67", 12000 },
                    { 10, false, 2021, 50, 4, 2, 5, 2, "Tracker", "ABC8D90", 8000 },
                    { 11, true, 2020, 60, 2, 3, 6, 2, "S10", "DEF1G23", 22000 },
                    { 12, false, 2019, 55, 1, 5, 6, 2, "Cruze", "GHI4J56", 40000 },
                    { 13, false, 2023, 40, 0, 1, 7, 3, "Ka", "JKL7M89", 7000 },
                    { 14, false, 2022, 50, 4, 0, 7, 3, "EcoSport", "MNO8P01", 15000 },
                    { 15, true, 2021, 70, 2, 3, 8, 3, "Ranger", "PQR9S23", 30000 }
                });

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
                name: "IX_TBAluguel_VeiculoId",
                table: "TBAluguel",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguelTaxa_TaxasId",
                table: "TBAluguelTaxa",
                column: "TaxasId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_ClienteId",
                table: "TBCondutor",
                column: "ClienteId");

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
                name: "TBAluguelTaxa");

            migrationBuilder.DropTable(
                name: "TBAluguel");

            migrationBuilder.DropTable(
                name: "TBTaxasEServicos");

            migrationBuilder.DropTable(
                name: "TBCondutor");

            migrationBuilder.DropTable(
                name: "TBPlano");

            migrationBuilder.DropTable(
                name: "TBVeiculos");

            migrationBuilder.DropTable(
                name: "TBCliente");

            migrationBuilder.DropTable(
                name: "TBGrupo");
        }
    }
}
