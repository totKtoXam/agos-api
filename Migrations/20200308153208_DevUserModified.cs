using Microsoft.EntityFrameworkCore.Migrations;

namespace AGoS_api.Migrations
{
    public partial class DevUserModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevUsers_AspNetUsers_UserId",
                table: "DevUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DevUsers",
                table: "DevUsers");

            migrationBuilder.DropIndex(
                name: "IX_DevUsers_UserId",
                table: "DevUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DevUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DevUsers");

            migrationBuilder.AddColumn<string>(
                name: "DevUserId",
                table: "DevUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IIN",
                table: "DevUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "DevUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevUsers",
                table: "DevUsers",
                column: "DevUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DevUsers",
                table: "DevUsers");

            migrationBuilder.DropColumn(
                name: "DevUserId",
                table: "DevUsers");

            migrationBuilder.DropColumn(
                name: "IIN",
                table: "DevUsers");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "DevUsers");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "DevUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DevUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevUsers",
                table: "DevUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DevUsers_UserId",
                table: "DevUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DevUsers_AspNetUsers_UserId",
                table: "DevUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
