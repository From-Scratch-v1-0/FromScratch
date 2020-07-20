using Microsoft.EntityFrameworkCore.Migrations;

namespace FS_DAL.Migrations
{
    public partial class PersonTableChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Person__UserKey__66603565",
                schema: "hr",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_UserKey",
                schema: "hr",
                table: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "UserKey",
                schema: "hr",
                table: "Person",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePic",
                schema: "hr",
                table: "Person",
                type: "nvarchar(1000)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                schema: "hr",
                table: "Person",
                column: "UserKey");

            migrationBuilder.AddForeignKey(
                name: "FK__Person__UserKey__66603565",
                schema: "hr",
                table: "Person",
                column: "UserKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Person__UserKey__66603565",
                schema: "hr",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                schema: "hr",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ProfilePic",
                schema: "hr",
                table: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "UserKey",
                schema: "hr",
                table: "Person",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserKey",
                schema: "hr",
                table: "Person",
                column: "UserKey");

            migrationBuilder.AddForeignKey(
                name: "FK__Person__UserKey__66603565",
                schema: "hr",
                table: "Person",
                column: "UserKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
