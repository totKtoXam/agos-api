using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AGoS_api.Migrations
{
    public partial class ModifiedDataBase3v : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_RepresentativeOrganizations_RepresentativeOrganiza~",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_RepresentativeOrganizationReprId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "RepresentativeOrganizationReprId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Classroom",
                table: "ClassroomOfTeachers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudyOrganizationId",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BIN",
                table: "StudyOrganizations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_StudyOrganizationId",
                table: "Teachers",
                column: "StudyOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_StudyOrganizations_StudyOrganizationId",
                table: "Teachers",
                column: "StudyOrganizationId",
                principalTable: "StudyOrganizations",
                principalColumn: "StudyOrganizationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_StudyOrganizations_StudyOrganizationId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_StudyOrganizationId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "StudyOrganizationId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "BIN",
                table: "StudyOrganizations");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Teachers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RepresentativeOrganizationReprId",
                table: "Teachers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Teachers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Classroom",
                table: "ClassroomOfTeachers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_RepresentativeOrganizationReprId",
                table: "Teachers",
                column: "RepresentativeOrganizationReprId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_RepresentativeOrganizations_RepresentativeOrganiza~",
                table: "Teachers",
                column: "RepresentativeOrganizationReprId",
                principalTable: "RepresentativeOrganizations",
                principalColumn: "ReprId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
