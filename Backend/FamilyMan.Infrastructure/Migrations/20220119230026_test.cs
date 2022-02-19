using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyMan.Infrastructure.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Families_FamilyId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Members_FamilyId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "Members");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FamilyId",
                table: "Members",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HeadId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    TodoPriority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_FamilyId",
                table: "Members",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Families_FamilyId",
                table: "Members",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id");
        }
    }
}
