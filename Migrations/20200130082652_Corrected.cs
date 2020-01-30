using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AGoS_api.Migrations
{
    public partial class Corrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "DayName",
                table: "WeekDays");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "DayFullName",
                table: "WeekDays",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DayShortName",
                table: "WeekDays",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RepresentativeOrganizationReprId",
                table: "StudyOrganizations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    ClassroomId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.ClassroomId);
                });

            migrationBuilder.CreateTable(
                name: "HolidayCalendars",
                columns: table => new
                {
                    HolidayCalendarId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Country = table.Column<string>(nullable: true),
                    DateHappyBegin = table.Column<DateTime>(nullable: false),
                    DateHappyEnd = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayCalendars", x => x.HolidayCalendarId);
                });

            migrationBuilder.CreateTable(
                name: "RepresentativeOrganization",
                columns: table => new
                {
                    ReprId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    PositionWork = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepresentativeOrganization", x => x.ReprId);
                });

            migrationBuilder.CreateTable(
                name: "Semestrs",
                columns: table => new
                {
                    SemestrId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseNum = table.Column<string>(nullable: true),
                    SpecialityId = table.Column<int>(nullable: true),
                    SemestrNum = table.Column<string>(nullable: true),
                    BeginOfSemestr = table.Column<DateTime>(nullable: false),
                    FinishOfSemestr = table.Column<DateTime>(nullable: false),
                    HoursWeek = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semestrs", x => x.SemestrId);
                    table.ForeignKey(
                        name: "FK_Semestrs_Specialitys_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialitys",
                        principalColumn: "SpecialityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeLessons",
                columns: table => new
                {
                    TypeLessonId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeLessonName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLessons", x => x.TypeLessonId);
                });

            migrationBuilder.CreateTable(
                name: "TypeWeeks",
                columns: table => new
                {
                    TypeWeekId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeWeekName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeWeeks", x => x.TypeWeekId);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomOfTeachers",
                columns: table => new
                {
                    ClassroomOfTeacherId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeacherId = table.Column<int>(nullable: true),
                    ClassroomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomOfTeachers", x => x.ClassroomOfTeacherId);
                    table.ForeignKey(
                        name: "FK_ClassroomOfTeachers_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "ClassroomId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassroomOfTeachers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    TypeLessonId = table.Column<int>(nullable: true),
                    Classifier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.DisciplineId);
                    table.ForeignKey(
                        name: "FK_Disciplines_TypeLessons_TypeLessonId",
                        column: x => x.TypeLessonId,
                        principalTable: "TypeLessons",
                        principalColumn: "TypeLessonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineSpecials",
                columns: table => new
                {
                    DisciplineSpecialId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpecialityOtdelId = table.Column<int>(nullable: true),
                    DisciplineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineSpecials", x => x.DisciplineSpecialId);
                    table.ForeignKey(
                        name: "FK_DisciplineSpecials_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "DisciplineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisciplineSpecials_SpecialityOtdels_SpecialityOtdelId",
                        column: x => x.SpecialityOtdelId,
                        principalTable: "SpecialityOtdels",
                        principalColumn: "SpecialityOtdelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeachDiscips",
                columns: table => new
                {
                    TeachDiscipId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisciplineId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachDiscips", x => x.TeachDiscipId);
                    table.ForeignKey(
                        name: "FK_TeachDiscips_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "DisciplineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeachDiscips_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcademicPlans",
                columns: table => new
                {
                    AcademicPlanId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SemestrId = table.Column<int>(nullable: true),
                    SpecialityId = table.Column<int>(nullable: true),
                    DisciplineSpecialId = table.Column<int>(nullable: true),
                    AllHours = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPlans", x => x.AcademicPlanId);
                    table.ForeignKey(
                        name: "FK_AcademicPlans_DisciplineSpecials_DisciplineSpecialId",
                        column: x => x.DisciplineSpecialId,
                        principalTable: "DisciplineSpecials",
                        principalColumn: "DisciplineSpecialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicPlans_Semestrs_SemestrId",
                        column: x => x.SemestrId,
                        principalTable: "Semestrs",
                        principalColumn: "SemestrId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicPlans_Specialitys_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialitys",
                        principalColumn: "SpecialityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyOrganizations_RepresentativeOrganizationReprId",
                table: "StudyOrganizations",
                column: "RepresentativeOrganizationReprId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPlans_DisciplineSpecialId",
                table: "AcademicPlans",
                column: "DisciplineSpecialId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPlans_SemestrId",
                table: "AcademicPlans",
                column: "SemestrId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPlans_SpecialityId",
                table: "AcademicPlans",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomOfTeachers_ClassroomId",
                table: "ClassroomOfTeachers",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomOfTeachers_TeacherId",
                table: "ClassroomOfTeachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_TypeLessonId",
                table: "Disciplines",
                column: "TypeLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineSpecials_DisciplineId",
                table: "DisciplineSpecials",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineSpecials_SpecialityOtdelId",
                table: "DisciplineSpecials",
                column: "SpecialityOtdelId");

            migrationBuilder.CreateIndex(
                name: "IX_Semestrs_SpecialityId",
                table: "Semestrs",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachDiscips_DisciplineId",
                table: "TeachDiscips",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachDiscips_TeacherId",
                table: "TeachDiscips",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyOrganizations_RepresentativeOrganization_Representativ~",
                table: "StudyOrganizations",
                column: "RepresentativeOrganizationReprId",
                principalTable: "RepresentativeOrganization",
                principalColumn: "ReprId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyOrganizations_RepresentativeOrganization_Representativ~",
                table: "StudyOrganizations");

            migrationBuilder.DropTable(
                name: "AcademicPlans");

            migrationBuilder.DropTable(
                name: "ClassroomOfTeachers");

            migrationBuilder.DropTable(
                name: "HolidayCalendars");

            migrationBuilder.DropTable(
                name: "RepresentativeOrganization");

            migrationBuilder.DropTable(
                name: "TeachDiscips");

            migrationBuilder.DropTable(
                name: "TypeWeeks");

            migrationBuilder.DropTable(
                name: "DisciplineSpecials");

            migrationBuilder.DropTable(
                name: "Semestrs");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "TypeLessons");

            migrationBuilder.DropIndex(
                name: "IX_StudyOrganizations_RepresentativeOrganizationReprId",
                table: "StudyOrganizations");

            migrationBuilder.DropColumn(
                name: "DayFullName",
                table: "WeekDays");

            migrationBuilder.DropColumn(
                name: "DayShortName",
                table: "WeekDays");

            migrationBuilder.DropColumn(
                name: "RepresentativeOrganizationReprId",
                table: "StudyOrganizations");

            migrationBuilder.AddColumn<string>(
                name: "DayName",
                table: "WeekDays",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Revoked = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });
        }
    }
}
