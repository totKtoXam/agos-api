using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AGoS_api.Migrations
{
    public partial class RefreshDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomOfTeachers_Classrooms_ClassroomId",
                table: "ClassroomOfTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyOrganizations_RepresentativeOrganizations_Representati~",
                table: "StudyOrganizations");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropIndex(
                name: "IX_StudyOrganizations_RepresentativeOrganizationReprId",
                table: "StudyOrganizations");

            migrationBuilder.DropIndex(
                name: "IX_ClassroomOfTeachers_ClassroomId",
                table: "ClassroomOfTeachers");

            migrationBuilder.DropColumn(
                name: "RepresentativeOrganizationReprId",
                table: "StudyOrganizations");

            migrationBuilder.DropColumn(
                name: "StudyLanguage",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "ClassroomOfTeachers");

            migrationBuilder.AddColumn<Guid>(
                name: "RepresentativeOrganizationReprId",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudyOrganizationId",
                table: "TeachDiscips",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SignDate",
                table: "StudyOrganizations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StudyOrganizationId",
                table: "Semestrs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudyOrganizationId",
                table: "RepresentativeOrganizations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GosHoliday",
                table: "HolidayCalendars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StudyOrganizationId",
                table: "HolidayCalendars",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudyLangLangId",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudyOrganizationId",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Classroom",
                table: "ClassroomOfTeachers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudyOrganizationId",
                table: "ClassroomOfTeachers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudyOrganizationId",
                table: "AcademicPlans",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LangId = table.Column<Guid>(nullable: false),
                    LanguageName = table.Column<string>(nullable: true),
                    LangCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LangId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_RepresentativeOrganizationReprId",
                table: "Teachers",
                column: "RepresentativeOrganizationReprId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachDiscips_StudyOrganizationId",
                table: "TeachDiscips",
                column: "StudyOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Semestrs_StudyOrganizationId",
                table: "Semestrs",
                column: "StudyOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativeOrganizations_StudyOrganizationId",
                table: "RepresentativeOrganizations",
                column: "StudyOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayCalendars_StudyOrganizationId",
                table: "HolidayCalendars",
                column: "StudyOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_StudyLangLangId",
                table: "Groups",
                column: "StudyLangLangId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_StudyOrganizationId",
                table: "Groups",
                column: "StudyOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomOfTeachers_StudyOrganizationId",
                table: "ClassroomOfTeachers",
                column: "StudyOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPlans_StudyOrganizationId",
                table: "AcademicPlans",
                column: "StudyOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicPlans_StudyOrganizations_StudyOrganizationId",
                table: "AcademicPlans",
                column: "StudyOrganizationId",
                principalTable: "StudyOrganizations",
                principalColumn: "StudyOrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomOfTeachers_StudyOrganizations_StudyOrganizationId",
                table: "ClassroomOfTeachers",
                column: "StudyOrganizationId",
                principalTable: "StudyOrganizations",
                principalColumn: "StudyOrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Languages_StudyLangLangId",
                table: "Groups",
                column: "StudyLangLangId",
                principalTable: "Languages",
                principalColumn: "LangId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_StudyOrganizations_StudyOrganizationId",
                table: "Groups",
                column: "StudyOrganizationId",
                principalTable: "StudyOrganizations",
                principalColumn: "StudyOrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayCalendars_StudyOrganizations_StudyOrganizationId",
                table: "HolidayCalendars",
                column: "StudyOrganizationId",
                principalTable: "StudyOrganizations",
                principalColumn: "StudyOrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentativeOrganizations_StudyOrganizations_StudyOrganiz~",
                table: "RepresentativeOrganizations",
                column: "StudyOrganizationId",
                principalTable: "StudyOrganizations",
                principalColumn: "StudyOrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Semestrs_StudyOrganizations_StudyOrganizationId",
                table: "Semestrs",
                column: "StudyOrganizationId",
                principalTable: "StudyOrganizations",
                principalColumn: "StudyOrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachDiscips_StudyOrganizations_StudyOrganizationId",
                table: "TeachDiscips",
                column: "StudyOrganizationId",
                principalTable: "StudyOrganizations",
                principalColumn: "StudyOrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_RepresentativeOrganizations_RepresentativeOrganiza~",
                table: "Teachers",
                column: "RepresentativeOrganizationReprId",
                principalTable: "RepresentativeOrganizations",
                principalColumn: "ReprId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicPlans_StudyOrganizations_StudyOrganizationId",
                table: "AcademicPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomOfTeachers_StudyOrganizations_StudyOrganizationId",
                table: "ClassroomOfTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Languages_StudyLangLangId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_StudyOrganizations_StudyOrganizationId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_HolidayCalendars_StudyOrganizations_StudyOrganizationId",
                table: "HolidayCalendars");

            migrationBuilder.DropForeignKey(
                name: "FK_RepresentativeOrganizations_StudyOrganizations_StudyOrganiz~",
                table: "RepresentativeOrganizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Semestrs_StudyOrganizations_StudyOrganizationId",
                table: "Semestrs");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachDiscips_StudyOrganizations_StudyOrganizationId",
                table: "TeachDiscips");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_RepresentativeOrganizations_RepresentativeOrganiza~",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_RepresentativeOrganizationReprId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_TeachDiscips_StudyOrganizationId",
                table: "TeachDiscips");

            migrationBuilder.DropIndex(
                name: "IX_Semestrs_StudyOrganizationId",
                table: "Semestrs");

            migrationBuilder.DropIndex(
                name: "IX_RepresentativeOrganizations_StudyOrganizationId",
                table: "RepresentativeOrganizations");

            migrationBuilder.DropIndex(
                name: "IX_HolidayCalendars_StudyOrganizationId",
                table: "HolidayCalendars");

            migrationBuilder.DropIndex(
                name: "IX_Groups_StudyLangLangId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_StudyOrganizationId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_ClassroomOfTeachers_StudyOrganizationId",
                table: "ClassroomOfTeachers");

            migrationBuilder.DropIndex(
                name: "IX_AcademicPlans_StudyOrganizationId",
                table: "AcademicPlans");

            migrationBuilder.DropColumn(
                name: "RepresentativeOrganizationReprId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "StudyOrganizationId",
                table: "TeachDiscips");

            migrationBuilder.DropColumn(
                name: "SignDate",
                table: "StudyOrganizations");

            migrationBuilder.DropColumn(
                name: "StudyOrganizationId",
                table: "Semestrs");

            migrationBuilder.DropColumn(
                name: "StudyOrganizationId",
                table: "RepresentativeOrganizations");

            migrationBuilder.DropColumn(
                name: "GosHoliday",
                table: "HolidayCalendars");

            migrationBuilder.DropColumn(
                name: "StudyOrganizationId",
                table: "HolidayCalendars");

            migrationBuilder.DropColumn(
                name: "StudyLangLangId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "StudyOrganizationId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Classroom",
                table: "ClassroomOfTeachers");

            migrationBuilder.DropColumn(
                name: "StudyOrganizationId",
                table: "ClassroomOfTeachers");

            migrationBuilder.DropColumn(
                name: "StudyOrganizationId",
                table: "AcademicPlans");

            migrationBuilder.AddColumn<Guid>(
                name: "RepresentativeOrganizationReprId",
                table: "StudyOrganizations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudyLanguage",
                table: "Groups",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassroomId",
                table: "ClassroomOfTeachers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    ClassroomId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.ClassroomId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyOrganizations_RepresentativeOrganizationReprId",
                table: "StudyOrganizations",
                column: "RepresentativeOrganizationReprId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomOfTeachers_ClassroomId",
                table: "ClassroomOfTeachers",
                column: "ClassroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomOfTeachers_Classrooms_ClassroomId",
                table: "ClassroomOfTeachers",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "ClassroomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyOrganizations_RepresentativeOrganizations_Representati~",
                table: "StudyOrganizations",
                column: "RepresentativeOrganizationReprId",
                principalTable: "RepresentativeOrganizations",
                principalColumn: "ReprId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
