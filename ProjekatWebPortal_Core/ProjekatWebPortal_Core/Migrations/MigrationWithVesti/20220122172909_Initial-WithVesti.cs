using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWebPortal_Core.Migrations.MigrationWithVesti
{
    public partial class InitialWithVesti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vesti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KratakOpis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumPostavljanja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vesti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeloVesti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VestId = table.Column<int>(type: "int", nullable: false),
                    TeloVesti = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeloVesti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeloVesti_Vesti_VestId",
                        column: x => x.VestId,
                        principalTable: "Vesti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeloVesti_VestId",
                table: "TeloVesti",
                column: "VestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeloVesti");

            migrationBuilder.DropTable(
                name: "Vesti");
        }
    }
}
