using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWebPortal_Core.Migrations.UsersMaterijal
{
    public partial class materijalEtc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "materijali",
                columns: table => new
                {
                    materijalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    materijalFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    fileMimeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    materijalOpis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datumMaterijali = table.Column<DateTime>(type: "datetime2", nullable: false),
                    materijalEkstenzija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    materijalNaziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    materijalNaslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    odobreno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obrazlozenje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipMaterijalId = table.Column<int>(type: "int", nullable: false),
                    Obrisan = table.Column<bool>(type: "bit", nullable: false),
                    namenaMaterijalaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materijali", x => x.materijalId);
                    table.ForeignKey(
                        name: "FK_materijali_nameneMaterijala_namenaMaterijalaId",
                        column: x => x.namenaMaterijalaId,
                        principalTable: "nameneMaterijala",
                        principalColumn: "namenaMaterijalaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_materijali_tipMaterijala_tipMaterijalId",
                        column: x => x.tipMaterijalId,
                        principalTable: "tipMaterijala",
                        principalColumn: "tipMaterijalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "moduli",
                columns: table => new
                {
                    modulId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    modulNaziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    modulOpis = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    predmetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moduli", x => x.modulId);
                    table.ForeignKey(
                        name: "FK_moduli_predmeti_predmetId",
                        column: x => x.predmetId,
                        principalTable: "predmeti",
                        principalColumn: "predmetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profesormaterijali",
                columns: table => new
                {
                    materijalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    materijalFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    fileMimeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    materijalOpis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    materijalEkstenzija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    materijalNaziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    materijalNaslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    predmetId = table.Column<int>(type: "int", nullable: true),
                    tipMaterijalId = table.Column<int>(type: "int", nullable: false),
                    namenaMaterijalaId = table.Column<int>(type: "int", nullable: false),
                    odobreno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obrazlozenje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    namenaMaterijalaModelnamenaMaterijalaId = table.Column<int>(type: "int", nullable: true),
                    TipMaterijalModeltipMaterijalId = table.Column<int>(type: "int", nullable: true),
                    PredmetModelpredmetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesormaterijali", x => x.materijalId);
                    table.ForeignKey(
                        name: "FK_Profesormaterijali_nameneMaterijala_namenaMaterijalaModelnamenaMaterijalaId",
                        column: x => x.namenaMaterijalaModelnamenaMaterijalaId,
                        principalTable: "nameneMaterijala",
                        principalColumn: "namenaMaterijalaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profesormaterijali_predmeti_PredmetModelpredmetId",
                        column: x => x.PredmetModelpredmetId,
                        principalTable: "predmeti",
                        principalColumn: "predmetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profesormaterijali_tipMaterijala_TipMaterijalModeltipMaterijalId",
                        column: x => x.TipMaterijalModeltipMaterijalId,
                        principalTable: "tipMaterijala",
                        principalColumn: "tipMaterijalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "globalniZahtevi",
                columns: table => new
                {
                    zahtevId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zahtevDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    zahtevObrazlozenje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZaGlobalnog = table.Column<bool>(type: "bit", nullable: false),
                    materijalId = table.Column<int>(type: "int", nullable: false),
                    predlozeniModul = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_globalniZahtevi", x => x.zahtevId);
                    table.ForeignKey(
                        name: "FK_globalniZahtevi_materijali_materijalId",
                        column: x => x.materijalId,
                        principalTable: "materijali",
                        principalColumn: "materijalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "materijalPoModulu",
                columns: table => new
                {
                    modulId = table.Column<int>(type: "int", nullable: false),
                    materijalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materijalPoModulu", x => new { x.materijalId, x.modulId });
                    table.ForeignKey(
                        name: "FK_materijalPoModulu_materijali_materijalId",
                        column: x => x.materijalId,
                        principalTable: "materijali",
                        principalColumn: "materijalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_materijalPoModulu_moduli_modulId",
                        column: x => x.modulId,
                        principalTable: "moduli",
                        principalColumn: "modulId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_globalniZahtevi_materijalId",
                table: "globalniZahtevi",
                column: "materijalId");

            migrationBuilder.CreateIndex(
                name: "IX_materijali_namenaMaterijalaId",
                table: "materijali",
                column: "namenaMaterijalaId");

            migrationBuilder.CreateIndex(
                name: "IX_materijali_tipMaterijalId",
                table: "materijali",
                column: "tipMaterijalId");

            migrationBuilder.CreateIndex(
                name: "IX_materijalPoModulu_modulId",
                table: "materijalPoModulu",
                column: "modulId");

            migrationBuilder.CreateIndex(
                name: "IX_moduli_predmetId",
                table: "moduli",
                column: "predmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesormaterijali_namenaMaterijalaModelnamenaMaterijalaId",
                table: "Profesormaterijali",
                column: "namenaMaterijalaModelnamenaMaterijalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesormaterijali_PredmetModelpredmetId",
                table: "Profesormaterijali",
                column: "PredmetModelpredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesormaterijali_TipMaterijalModeltipMaterijalId",
                table: "Profesormaterijali",
                column: "TipMaterijalModeltipMaterijalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "globalniZahtevi");

            migrationBuilder.DropTable(
                name: "materijalPoModulu");

            migrationBuilder.DropTable(
                name: "Profesormaterijali");

            migrationBuilder.DropTable(
                name: "materijali");

            migrationBuilder.DropTable(
                name: "moduli");
        }
    }
}
