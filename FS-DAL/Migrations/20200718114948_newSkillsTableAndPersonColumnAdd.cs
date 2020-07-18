using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FS_DAL.Migrations
{
    public partial class newSkillsTableAndPersonColumnAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "hr",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "hr",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                schema: "hr",
                table: "Person",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                schema: "hr",
                table: "Person",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Education",
                schema: "hr",
                table: "Person",
                type: "nvarchar(400)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "hr",
                table: "Person",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Proffesion",
                schema: "hr",
                table: "Person",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "hr",
                columns: table => new
                {
                    SkillKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    UserFKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillKey);
                    table.ForeignKey(
                        name: "FK_Skills_AspNetUsers_UserFKey",
                        column: x => x.UserFKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UserFKey",
                schema: "hr",
                table: "Skills",
                column: "UserFKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills",
                schema: "hr");

            migrationBuilder.DropColumn(
                name: "AboutMe",
                schema: "hr",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                schema: "hr",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Education",
                schema: "hr",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "hr",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Proffesion",
                schema: "hr",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "hr",
                table: "Person",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "hr",
                table: "Person",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
