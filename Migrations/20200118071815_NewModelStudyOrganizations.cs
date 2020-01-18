using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AGoS_api.Migrations
{
    public partial class NewModelStudyOrganizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "devUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_devUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudyOrganizations",
                columns: table => new
                {
                    StudyOrganizationId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OfficialName = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    AddressName = table.Column<string>(nullable: true),
                    NumOfHome = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyOrganizations", x => x.StudyOrganizationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_devUsers_UserId",
                table: "devUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "devUsers");

            migrationBuilder.DropTable(
                name: "StudyOrganizations");
        }
    }
}
