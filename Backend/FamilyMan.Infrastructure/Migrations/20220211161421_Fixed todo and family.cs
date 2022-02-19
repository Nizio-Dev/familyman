using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyMan.Infrastructure.Migrations
{
    public partial class Fixedtodoandfamily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Families_FamilyId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_FamilyId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "Members");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Todos",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "HeadId",
                table: "Families",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "FamilyMember",
                columns: table => new
                {
                    FamiliesId = table.Column<Guid>(type: "uuid", nullable: false),
                    MembersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMember", x => new { x.FamiliesId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_FamilyMember_Families_FamiliesId",
                        column: x => x.FamiliesId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyMember_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_OwnerId",
                table: "Todos",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Families_HeadId",
                table: "Families",
                column: "HeadId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMember_MembersId",
                table: "FamilyMember",
                column: "MembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Families_Members_HeadId",
                table: "Families",
                column: "HeadId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Members_OwnerId",
                table: "Todos",
                column: "OwnerId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_Members_HeadId",
                table: "Families");

            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Members_OwnerId",
                table: "Todos");

            migrationBuilder.DropTable(
                name: "FamilyMember");

            migrationBuilder.DropIndex(
                name: "IX_Todos_OwnerId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Families_HeadId",
                table: "Families");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Todos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FamilyId",
                table: "Members",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "HeadId",
                table: "Families",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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
