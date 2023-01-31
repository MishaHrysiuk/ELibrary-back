using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELibrary.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArenaId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_ArenaId",
                table: "Books",
                column: "ArenaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Arenas_ArenaId",
                table: "Books",
                column: "ArenaId",
                principalTable: "Arenas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Arenas_ArenaId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ArenaId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ArenaId",
                table: "Books");
        }
    }
}
