using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWebPortal_Core.Migrations.UsersMaterijal
{
    public partial class smeroviPoSkolama : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "smeroviPoSkolama",
                columns: table => new
                {
                    skolaId = table.Column<int>(type: "int", nullable: false),
                    smerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_smeroviPoSkolama", x => new { x.skolaId, x.smerId });
                    table.ForeignKey(
                        name: "FK_smeroviPoSkolama_Skola_skolaId",
                        column: x => x.skolaId,
                        principalTable: "Skola",
                        principalColumn: "IdSkole",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_smeroviPoSkolama_Smer_smerId",
                        column: x => x.smerId,
                        principalTable: "Smer",
                        principalColumn: "smerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_smeroviPoSkolama_smerId",
                table: "smeroviPoSkolama",
                column: "smerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "smeroviPoSkolama");
        }
    }
}
