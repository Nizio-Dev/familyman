using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyMan.Infrastructure.Migrations
{
    public partial class Changednametoemailformemberentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Members",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Members",
                newName: "Name");
        }
    }
}
