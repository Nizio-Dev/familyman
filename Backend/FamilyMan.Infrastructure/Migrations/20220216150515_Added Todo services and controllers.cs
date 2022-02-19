using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyMan.Infrastructure.Migrations
{
    public partial class AddedTodoservicesandcontrollers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TodoPriority",
                table: "Todos",
                newName: "Priority");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Todos",
                newName: "TodoPriority");
        }
    }
}
