using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWebPortal_Core.Migrations.UsersMaterijal
{
    public partial class forumiEtc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forum_Message",
                columns: table => new
                {
                    Id_message = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    messagePost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    messageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    odobrenje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_post = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum_Message", x => x.Id_message);
                    table.ForeignKey(
                        name: "FK_Forum_Message_Forum_Posts_Id_post",
                        column: x => x.Id_post,
                        principalTable: "Forum_Posts",
                        principalColumn: "Id_post",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forum_Message_Id_post",
                table: "Forum_Message",
                column: "Id_post");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forum_Message");
        }
    }
}
