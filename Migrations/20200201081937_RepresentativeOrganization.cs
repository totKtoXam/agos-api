using Microsoft.EntityFrameworkCore.Migrations;

namespace AGoS_api.Migrations
{
    public partial class RepresentativeOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyOrganizations_RepresentativeOrganization_Representativ~",
                table: "StudyOrganizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepresentativeOrganization",
                table: "RepresentativeOrganization");

            migrationBuilder.RenameTable(
                name: "RepresentativeOrganization",
                newName: "RepresentativeOrganizations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepresentativeOrganizations",
                table: "RepresentativeOrganizations",
                column: "ReprId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyOrganizations_RepresentativeOrganizations_Representati~",
                table: "StudyOrganizations",
                column: "RepresentativeOrganizationReprId",
                principalTable: "RepresentativeOrganizations",
                principalColumn: "ReprId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyOrganizations_RepresentativeOrganizations_Representati~",
                table: "StudyOrganizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepresentativeOrganizations",
                table: "RepresentativeOrganizations");

            migrationBuilder.RenameTable(
                name: "RepresentativeOrganizations",
                newName: "RepresentativeOrganization");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepresentativeOrganization",
                table: "RepresentativeOrganization",
                column: "ReprId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyOrganizations_RepresentativeOrganization_Representativ~",
                table: "StudyOrganizations",
                column: "RepresentativeOrganizationReprId",
                principalTable: "RepresentativeOrganization",
                principalColumn: "ReprId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
