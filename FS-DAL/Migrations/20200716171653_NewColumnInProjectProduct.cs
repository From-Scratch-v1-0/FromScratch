using Microsoft.EntityFrameworkCore.Migrations;

namespace FS_DAL.Migrations
{
    public partial class NewColumnInProjectProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                schema: "project",
                table: "ProjectProduct",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                schema: "project",
                table: "ProjectProduct");
        }
    }
}
