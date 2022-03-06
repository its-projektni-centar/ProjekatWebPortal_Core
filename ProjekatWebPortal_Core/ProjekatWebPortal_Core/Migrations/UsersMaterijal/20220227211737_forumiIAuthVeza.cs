using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekatWebPortal_Core.Migrations.UsersMaterijal
{
    public partial class forumiIAuthVeza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forum_Posts",
                columns: table => new
                {
                    Id_post = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    posttitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    postmessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    posteddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    approved = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    imgTema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aspNetUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum_Posts", x => x.Id_post);
                    table.ForeignKey(
                        name: "FK_Forum_Posts_AspNetUsers_aspNetUserId",
                        column: x => x.aspNetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forum_Posts_aspNetUserId",
                table: "Forum_Posts",
                column: "aspNetUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forum_Posts");
        }
    }
}
