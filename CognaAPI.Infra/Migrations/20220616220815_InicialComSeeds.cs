using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CognaAPI.Infra.Migrations
{
    public partial class InicialComSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataLembrete = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Concluido = table.Column<bool>(type: "bit", nullable: false),
                    Criado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaModificacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Concluido", "Criado", "DataLembrete", "Descricao", "UltimaModificacao" },
                values: new object[] { new Guid("03e68c0c-1164-43c9-6bb9-08d9e34472ad"), false, new DateTime(2022, 6, 16, 19, 8, 15, 853, DateTimeKind.Local).AddTicks(5880), new DateTime(2022, 6, 17, 19, 8, 15, 853, DateTimeKind.Local).AddTicks(5879), "Fazer Macarronada", null });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Concluido", "Criado", "DataLembrete", "Descricao", "UltimaModificacao" },
                values: new object[] { new Guid("5aa6c1d0-0eb4-4dae-8813-08d9e2b4aa87"), false, new DateTime(2022, 6, 16, 19, 8, 15, 853, DateTimeKind.Local).AddTicks(5853), new DateTime(2022, 6, 18, 19, 8, 15, 853, DateTimeKind.Local).AddTicks(5841), "Comprar Utensílios de cozinha", null });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Concluido", "Criado", "DataLembrete", "Descricao", "UltimaModificacao" },
                values: new object[] { new Guid("69881eb1-b47e-4d56-6bc1-08d9e34472ad"), false, new DateTime(2022, 6, 16, 19, 8, 15, 853, DateTimeKind.Local).AddTicks(5888), new DateTime(2022, 6, 21, 19, 8, 15, 853, DateTimeKind.Local).AddTicks(5887), "Buscar encomenda", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
