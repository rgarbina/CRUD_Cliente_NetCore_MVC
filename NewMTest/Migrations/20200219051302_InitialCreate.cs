using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewMTest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInclusao = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    DataEdicao = table.Column<DateTime>(nullable: false),
                    Ativado = table.Column<bool>(nullable: false, defaultValue: true),
                    Nome = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Endereco = table.Column<string>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 300, nullable: true),
                    Celular = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                });

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "PessoaId", "Ativado", "Celular", "Cpf", "DataEdicao", "DataInclusao", "DataNascimento", "Email", "Endereco", "Nome", "Observacao" },
                values: new object[] { 1L, true, "17981515290", "70258976047", new DateTime(2020, 2, 19, 2, 13, 1, 849, DateTimeKind.Local).AddTicks(6852), new DateTime(2020, 2, 19, 2, 13, 1, 849, DateTimeKind.Local).AddTicks(5490), new DateTime(1994, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "raphael@hotmail.com", "rua matias de albuquerque 1371 jardim maria lucia", "Raphael dos Santos Garbina", "Desenvolvedor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
