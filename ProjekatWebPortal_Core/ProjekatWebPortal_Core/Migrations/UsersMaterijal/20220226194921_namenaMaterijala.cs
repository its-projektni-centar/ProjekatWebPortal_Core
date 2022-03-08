using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWebPortal_Core.Migrations.UsersMaterijal
{
    public partial class namenaMaterijala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nameneMaterijala",
                columns: table => new
                {
                    namenaMaterijalaId = table.Column<int>(type: "int", nullable: false),
                    namenaMaterijalaNaziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nameneMaterijala", x => x.namenaMaterijalaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nameneMaterijala");
        }
    }
}
