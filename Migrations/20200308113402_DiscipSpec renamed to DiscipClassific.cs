using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AGoS_api.Migrations
{
    public partial class DiscipSpecrenamedtoDiscipClassific : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicPlans_DisciplineSpecials_DisciplineSpecialId",
                table: "AcademicPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachDiscips_StudyOrganizations_StudyOrganizationId",
                table: "TeachDiscips");

            migrationBuilder.DropTable(
                name: "DisciplineSpecials");

            migrationBuilder.DropIndex(
                name: "IX_TeachDiscips_StudyOrganizationId",
                table: "TeachDiscips");

            migrationBuilder.DropIndex(
                name: "IX_AcademicPlans_DisciplineSpecialId",
                table: "AcademicPlans");

            migrationBuilder.DropColumn(
                name: "StudyOrganizationId",
                table: "TeachDiscips");

            migrationBuilder.DropColumn(
                name: "DisciplineSpecialId",
                table: "AcademicPlans");

            migrationBuilder.AlterColumn<string>(
                name: "BIN",
                table: "StudyOrganizations",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisciplineSpecialDisciplineClassificId",
                table: "AcademicPlans",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DisciplineClassifics",
                columns: table => new
                {
                    DisciplineClassificId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassificationId = table.Column<int>(nullable: true),
                    DisciplineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineClassifics", x => x.DisciplineClassificId);
                    table.ForeignKey(
                        name: "FK_DisciplineClassifics_Classifications_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classifications",
                        principalColumn: "ClassificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisciplineClassifics_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "DisciplineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPlans_DisciplineSpecialDisciplineClassificId",
                table: "AcademicPlans",
                column: "DisciplineSpecialDisciplineClassificId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineClassifics_ClassificationId",
                table: "DisciplineClassifics",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineClassifics_DisciplineId",
                table: "DisciplineClassifics",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicPlans_DisciplineClassifics_DisciplineSpecialDiscipl~",
                table: "AcademicPlans",
                column: "DisciplineSpecialDisciplineClassificId",
                principalTable: "DisciplineClassifics",
                principalColumn: "DisciplineClassificId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicPlans_DisciplineClassifics_DisciplineSpecialDiscipl~",
                table: "AcademicPlans");

            migrationBuilder.DropTable(
                name: "DisciplineClassifics");

            migrationBuilder.DropIndex(
                name: "IX_AcademicPlans_DisciplineSpecialDisciplineClassificId",
                table: "AcademicPlans");

            migrationBuilder.DropColumn(
                name: "DisciplineSpecialDisciplineClassificId",
                table: "AcademicPlans");

            migrationBuilder.AddColumn<int>(
                name: "StudyOrganizationId",
                table: "TeachDiscips",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BIN",
                table: "StudyOrganizations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisciplineSpecialId",
                table: "AcademicPlans",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DisciplineSpecials",
                columns: table => new
                {
                    DisciplineSpecialId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisciplineId = table.Column<int>(type: "integer", nullable: true),
                    SpecialityId = table.Column<int>(type: "integer", nullable: true)
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
                        name: "FK_DisciplineSpecials_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "SpecialityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeachDiscips_StudyOrganizationId",
                table: "TeachDiscips",
                column: "StudyOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPlans_DisciplineSpecialId",
                table: "AcademicPlans",
                column: "DisciplineSpecialId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineSpecials_DisciplineId",
                table: "DisciplineSpecials",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineSpecials_SpecialityId",
                table: "DisciplineSpecials",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicPlans_DisciplineSpecials_DisciplineSpecialId",
                table: "AcademicPlans",
                column: "DisciplineSpecialId",
                principalTable: "DisciplineSpecials",
                principalColumn: "DisciplineSpecialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachDiscips_StudyOrganizations_StudyOrganizationId",
                table: "TeachDiscips",
                column: "StudyOrganizationId",
                principalTable: "StudyOrganizations",
                principalColumn: "StudyOrganizationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
