using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWebPortal_Core.Migrations.UsersMaterijal
{
    public partial class skoleISmerov : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skola",
                columns: table => new
                {
                    IdSkole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivSkole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skraceno = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skola", x => x.IdSkole);
                });

            migrationBuilder.CreateTable(
                name: "Smer",
                columns: table => new
                {
                    smerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    smerNaziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    smerOpis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    smerSkraceno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nazivFajlIts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fajlIts = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    fileMimeTypeIts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileEkstenzijaIts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nazivFajlNs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fajlNs = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    fileMimeTypeNs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileEkstenzijaNs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fajlMs = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    fileMimeTypeMs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileEkstenzijaMs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nazivFajlMs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmerModelsmerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smer", x => x.smerId);
                    table.ForeignKey(
                        name: "FK_Smer_Smer_SmerModelsmerId",
                        column: x => x.SmerModelsmerId,
                        principalTable: "Smer",
                        principalColumn: "smerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Smer_SmerModelsmerId",
                table: "Smer",
                column: "SmerModelsmerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skola");

            migrationBuilder.DropTable(
                name: "Smer");
        }
    }
}
