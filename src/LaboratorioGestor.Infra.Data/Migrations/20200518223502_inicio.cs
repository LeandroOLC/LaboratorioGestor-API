using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaboratorioGestor.Infra.Data.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Fone1 = table.Column<string>(type: "varchar(30)", nullable: true),
                    Fone2 = table.Column<string>(type: "varchar(30)", nullable: true),
                    Celular = table.Column<string>(type: "varchar(30)", nullable: true),
                    CelularWhatApp = table.Column<string>(type: "varchar(30)", nullable: true),
                    DataDoCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    TipoContato = table.Column<int>(type: "int", fixedLength: true, nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Proprietario = table.Column<string>(type: "varchar(100)", nullable: true),
                    TPO = table.Column<string>(type: "varchar(50)", nullable: true),
                    Documento = table.Column<string>(type: "varchar(30)", nullable: true),
                    TipoPessoa = table.Column<string>(type: "varchar(2)", nullable: false),
                    DataDoCadastro = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proteticos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: true),
                    PercentualDaComissao = table.Column<double>(nullable: false),
                    DataDoCadastro = table.Column<DateTime>(type: "DateTime", nullable: true),
                    CPF = table.Column<string>(type: "varchar(30)", nullable: true),
                    IDContato = table.Column<Guid>(type: "UniqueIdentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proteticos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proteticos_Contatos_IDContato",
                        column: x => x.IDContato,
                        principalTable: "Contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proteticos_IDContato",
                table: "Proteticos",
                column: "IDContato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laboratorios");

            migrationBuilder.DropTable(
                name: "Proteticos");

            migrationBuilder.DropTable(
                name: "Contatos");
        }
    }
}
