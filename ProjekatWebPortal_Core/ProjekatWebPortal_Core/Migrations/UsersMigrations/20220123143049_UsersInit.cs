using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWebPortal_Core.Migrations.UsersMigrations
{
    public partial class UsersInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skola");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
