using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AGoS_api.Migrations
{
    public partial class RemoveSpecialityFromAcademicPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicPlans_Specialities_SpecialityId",
                table: "AcademicPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineSpecials_ClassificationSpecialities_Classification~",
                table: "DisciplineSpecials");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_ClassificationSpecialities_ClassificationSpecialityId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "ClassificationSpecialities");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ClassificationSpecialityId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineSpecials_ClassificationSpecialityId",
                table: "DisciplineSpecials");

            migrationBuilder.DropIndex(
                name: "IX_AcademicPlans_SpecialityId",
                table: "AcademicPlans");

            migrationBuilder.DropColumn(
                name: "ClassificationSpecialityId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ClassificationSpecialityId",
                table: "DisciplineSpecials");

            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "AcademicPlans");

            migrationBuilder.AddColumn<int>(
                name: "ClassificationId",
                table: "Specialities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "DisciplineSpecials",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_ClassificationId",
                table: "Specialities",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialityId",
                table: "Groups",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineSpecials_SpecialityId",
                table: "DisciplineSpecials",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineSpecials_Specialities_SpecialityId",
                table: "DisciplineSpecials",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "SpecialityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Specialities_SpecialityId",
                table: "Groups",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "SpecialityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialities_Classifications_ClassificationId",
                table: "Specialities",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "ClassificationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineSpecials_Specialities_SpecialityId",
                table: "DisciplineSpecials");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Specialities_SpecialityId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialities_Classifications_ClassificationId",
                table: "Specialities");

            migrationBuilder.DropIndex(
                name: "IX_Specialities_ClassificationId",
                table: "Specialities");

            migrationBuilder.DropIndex(
                name: "IX_Groups_SpecialityId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineSpecials_SpecialityId",
                table: "DisciplineSpecials");

            migrationBuilder.DropColumn(
                name: "ClassificationId",
                table: "Specialities");

            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "DisciplineSpecials");

            migrationBuilder.AddColumn<int>(
                name: "ClassificationSpecialityId",
                table: "Groups",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassificationSpecialityId",
                table: "DisciplineSpecials",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "AcademicPlans",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassificationSpecialities",
                columns: table => new
                {
                    ClassificationSpecialityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassificationId = table.Column<int>(type: "integer", nullable: true),
                    SpecialityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationSpecialities", x => x.ClassificationSpecialityId);
                    table.ForeignKey(
                        name: "FK_ClassificationSpecialities_Classifications_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classifications",
                        principalColumn: "ClassificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassificationSpecialities_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "SpecialityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ClassificationSpecialityId",
                table: "Groups",
                column: "ClassificationSpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineSpecials_ClassificationSpecialityId",
                table: "DisciplineSpecials",
                column: "ClassificationSpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPlans_SpecialityId",
                table: "AcademicPlans",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassificationSpecialities_ClassificationId",
                table: "ClassificationSpecialities",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassificationSpecialities_SpecialityId",
                table: "ClassificationSpecialities",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicPlans_Specialities_SpecialityId",
                table: "AcademicPlans",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "SpecialityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineSpecials_ClassificationSpecialities_Classification~",
                table: "DisciplineSpecials",
                column: "ClassificationSpecialityId",
                principalTable: "ClassificationSpecialities",
                principalColumn: "ClassificationSpecialityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_ClassificationSpecialities_ClassificationSpecialityId",
                table: "Groups",
                column: "ClassificationSpecialityId",
                principalTable: "ClassificationSpecialities",
                principalColumn: "ClassificationSpecialityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
