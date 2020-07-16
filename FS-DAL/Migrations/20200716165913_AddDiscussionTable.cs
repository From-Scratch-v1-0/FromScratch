using Microsoft.EntityFrameworkCore.Migrations;

namespace FS_DAL.Migrations
{
    public partial class AddDiscussionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "comment");

            migrationBuilder.CreateTable(
                name: "Discussion",
                schema: "comment",
                columns: table => new
                {
                    DiscussionKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserKey = table.Column<string>(nullable: true),
                    ProjectProductKey = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussion", x => x.DiscussionKey);
                    table.ForeignKey(
                        name: "FK_Discussion_ProjectProduct_ProjectProductKey",
                        column: x => x.ProjectProductKey,
                        principalSchema: "project",
                        principalTable: "ProjectProduct",
                        principalColumn: "ProjectKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discussion_AspNetUsers_UserKey",
                        column: x => x.UserKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discussion_ProjectProductKey",
                schema: "comment",
                table: "Discussion",
                column: "ProjectProductKey");

            migrationBuilder.CreateIndex(
                name: "IX_Discussion_UserKey",
                schema: "comment",
                table: "Discussion",
                column: "UserKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discussion",
                schema: "comment");
        }
    }
}
