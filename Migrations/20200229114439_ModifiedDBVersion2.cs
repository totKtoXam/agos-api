using Microsoft.EntityFrameworkCore.Migrations;

namespace AGoS_api.Migrations
{
    public partial class ModifiedDBVersion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialities_Classifications_ClassificationId",
                table: "Specialities");

            migrationBuilder.DropIndex(
                name: "IX_Specialities_ClassificationId",
                table: "Specialities");

            migrationBuilder.DropColumn(
                name: "ClassificationId",
                table: "Specialities");

            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "Classifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classifications_SpecialityId",
                table: "Classifications",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classifications_Specialities_SpecialityId",
                table: "Classifications",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "SpecialityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classifications_Specialities_SpecialityId",
                table: "Classifications");

            migrationBuilder.DropIndex(
                name: "IX_Classifications_SpecialityId",
                table: "Classifications");

            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "Classifications");

            migrationBuilder.AddColumn<int>(
                name: "ClassificationId",
                table: "Specialities",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_ClassificationId",
                table: "Specialities",
                column: "ClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialities_Classifications_ClassificationId",
                table: "Specialities",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "ClassificationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
