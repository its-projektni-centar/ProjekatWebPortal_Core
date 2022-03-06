using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWebPortal_Core.Migrations.UsersMaterijal
{
    public partial class predmetiITipPredmeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tipPredmeta",
                columns: table => new
                {
                    tipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipNaziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipPredmeta", x => x.tipId);
                });

            migrationBuilder.CreateTable(
                name: "predmeti",
                columns: table => new
                {
                    predmetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    predmetNaziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    predmetOpis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipId = table.Column<int>(type: "int", nullable: false),
                    Razred = table.Column<int>(type: "int", nullable: true),
                    PredmetModelpredmetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_predmeti", x => x.predmetId);
                    table.ForeignKey(
                        name: "FK_predmeti_predmeti_PredmetModelpredmetId",
                        column: x => x.PredmetModelpredmetId,
                        principalTable: "predmeti",
                        principalColumn: "predmetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_predmeti_tipPredmeta_tipId",
                        column: x => x.tipId,
                        principalTable: "tipPredmeta",
                        principalColumn: "tipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_predmeti_PredmetModelpredmetId",
                table: "predmeti",
                column: "PredmetModelpredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_predmeti_tipId",
                table: "predmeti",
                column: "tipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "predmeti");

            migrationBuilder.DropTable(
                name: "tipPredmeta");
        }
    }
}
