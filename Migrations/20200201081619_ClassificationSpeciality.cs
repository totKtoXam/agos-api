using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AGoS_api.Migrations
{
    public partial class ClassificationSpeciality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineSpecials_SpecialityOtdels_SpecialityOtdelId",
                table: "DisciplineSpecials");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_SpecialityOtdels_SpecialityOtdelId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "SpecialityOtdels");

            migrationBuilder.DropTable(
                name: "Otdels");

            migrationBuilder.DropIndex(
                name: "IX_Groups_SpecialityOtdelId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineSpecials_SpecialityOtdelId",
                table: "DisciplineSpecials");

            migrationBuilder.DropColumn(
                name: "Speciality_Classifier",
                table: "Specialitys");

            migrationBuilder.DropColumn(
                name: "Speciality_Name",
                table: "Specialitys");

            migrationBuilder.DropColumn(
                name: "SpecialityOtdelId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SpecialityOtdelId",
                table: "DisciplineSpecials");

            migrationBuilder.AddColumn<string>(
                name: "SpecialityClassifier",
                table: "Specialitys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialityName",
                table: "Specialitys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassificationSpecialityId",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassificationSpecialityId",
                table: "DisciplineSpecials",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Classifications",
                columns: table => new
                {
                    ClassificationId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassificationName = table.Column<string>(nullable: true),
                    ClassificationClassifier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifications", x => x.ClassificationId);
                });

            migrationBuilder.CreateTable(
                name: "ClassificationSpecialitys",
                columns: table => new
                {
                    ClassificationSpecialityId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassificationId = table.Column<int>(nullable: true),
                    SpecialityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationSpecialitys", x => x.ClassificationSpecialityId);
                    table.ForeignKey(
                        name: "FK_ClassificationSpecialitys_Classifications_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classifications",
                        principalColumn: "ClassificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassificationSpecialitys_Specialitys_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialitys",
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
                name: "IX_ClassificationSpecialitys_ClassificationId",
                table: "ClassificationSpecialitys",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassificationSpecialitys_SpecialityId",
                table: "ClassificationSpecialitys",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineSpecials_ClassificationSpecialitys_Classification~",
                table: "DisciplineSpecials",
                column: "ClassificationSpecialityId",
                principalTable: "ClassificationSpecialitys",
                principalColumn: "ClassificationSpecialityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_ClassificationSpecialitys_ClassificationSpecialityId",
                table: "Groups",
                column: "ClassificationSpecialityId",
                principalTable: "ClassificationSpecialitys",
                principalColumn: "ClassificationSpecialityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineSpecials_ClassificationSpecialitys_Classification~",
                table: "DisciplineSpecials");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_ClassificationSpecialitys_ClassificationSpecialityId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "ClassificationSpecialitys");

            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ClassificationSpecialityId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineSpecials_ClassificationSpecialityId",
                table: "DisciplineSpecials");

            migrationBuilder.DropColumn(
                name: "SpecialityClassifier",
                table: "Specialitys");

            migrationBuilder.DropColumn(
                name: "SpecialityName",
                table: "Specialitys");

            migrationBuilder.DropColumn(
                name: "ClassificationSpecialityId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ClassificationSpecialityId",
                table: "DisciplineSpecials");

            migrationBuilder.AddColumn<string>(
                name: "Speciality_Classifier",
                table: "Specialitys",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speciality_Name",
                table: "Specialitys",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityOtdelId",
                table: "Groups",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityOtdelId",
                table: "DisciplineSpecials",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Otdels",
                columns: table => new
                {
                    OtdelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OtdelName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otdels", x => x.OtdelId);
                });

            migrationBuilder.CreateTable(
                name: "SpecialityOtdels",
                columns: table => new
                {
                    SpecialityOtdelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OtdelId = table.Column<int>(type: "integer", nullable: true),
                    SpecialityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialityOtdels", x => x.SpecialityOtdelId);
                    table.ForeignKey(
                        name: "FK_SpecialityOtdels_Otdels_OtdelId",
                        column: x => x.OtdelId,
                        principalTable: "Otdels",
                        principalColumn: "OtdelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialityOtdels_Specialitys_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialitys",
                        principalColumn: "SpecialityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialityOtdelId",
                table: "Groups",
                column: "SpecialityOtdelId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineSpecials_SpecialityOtdelId",
                table: "DisciplineSpecials",
                column: "SpecialityOtdelId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialityOtdels_OtdelId",
                table: "SpecialityOtdels",
                column: "OtdelId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialityOtdels_SpecialityId",
                table: "SpecialityOtdels",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineSpecials_SpecialityOtdels_SpecialityOtdelId",
                table: "DisciplineSpecials",
                column: "SpecialityOtdelId",
                principalTable: "SpecialityOtdels",
                principalColumn: "SpecialityOtdelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_SpecialityOtdels_SpecialityOtdelId",
                table: "Groups",
                column: "SpecialityOtdelId",
                principalTable: "SpecialityOtdels",
                principalColumn: "SpecialityOtdelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
