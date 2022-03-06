using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWebPortal_Core.Migrations.UsersMaterijal
{
    public partial class predmetPoSmeru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "predmetiPoSmeru",
                columns: table => new
                {
                    predmetId = table.Column<int>(type: "int", nullable: false),
                    smerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_predmetiPoSmeru", x => new { x.predmetId, x.smerId });
                    table.ForeignKey(
                        name: "FK_predmetiPoSmeru_predmeti_predmetId",
                        column: x => x.predmetId,
                        principalTable: "predmeti",
                        principalColumn: "predmetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_predmetiPoSmeru_Smer_smerId",
                        column: x => x.smerId,
                        principalTable: "Smer",
                        principalColumn: "smerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_predmetiPoSmeru_smerId",
                table: "predmetiPoSmeru",
                column: "smerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "predmetiPoSmeru");
        }
    }
}
