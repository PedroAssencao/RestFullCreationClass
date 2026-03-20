using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestFullAPIMVC.API.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    IdAluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Aluno__8092FCB33AC61EE7", x => x.IdAluno);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DuracaoSemestres = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Curso__085F27D682F25C77", x => x.IdCurso);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    IdMatricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    DataMatricula = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "('Ativa')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Matricul__AD06C20FB86F020A", x => x.IdMatricula);
                    table.ForeignKey(
                        name: "FK__Matricula__IdAlu__3C69FB99",
                        column: x => x.IdAluno,
                        principalTable: "Aluno",
                        principalColumn: "IdAluno");
                    table.ForeignKey(
                        name: "FK__Matricula__IdCur__3D5E1FD2",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "IdCurso");
                });

            migrationBuilder.CreateTable(
                name: "Boleto",
                columns: table => new
                {
                    IdBoleto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMatricula = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "('Pendente')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Boleto__362F6EA0D43CAA45", x => x.IdBoleto);
                    table.ForeignKey(
                        name: "FK__Boleto__IdMatric__412EB0B6",
                        column: x => x.IdMatricula,
                        principalTable: "Matricula",
                        principalColumn: "IdMatricula");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boleto_IdMatricula",
                table: "Boleto",
                column: "IdMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_IdAluno",
                table: "Matricula",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_IdCurso",
                table: "Matricula",
                column: "IdCurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boleto");

            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
