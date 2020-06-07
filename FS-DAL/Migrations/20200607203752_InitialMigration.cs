using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FS_DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.EnsureSchema(
                name: "hr");

            migrationBuilder.EnsureSchema(
                name: "project");

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "core",
                columns: table => new
                {
                    CountryKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Country__B92CEBD450B06B79", x => x.CountryKey);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                schema: "hr",
                columns: table => new
                {
                    GenderKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Gender__44C092CDFD0FE67E", x => x.GenderKey);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                schema: "hr",
                columns: table => new
                {
                    UserTypeKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserType__8002849E07A2BA12", x => x.UserTypeKey);
                });

            migrationBuilder.CreateTable(
                name: "ProjectType",
                schema: "project",
                columns: table => new
                {
                    ProjectTypeKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTypeName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjectT__4BF49607019B42CF", x => x.ProjectTypeKey);
                });

            migrationBuilder.CreateTable(
                name: "Sphere",
                schema: "project",
                columns: table => new
                {
                    SphereKey = table.Column<int>(nullable: false),
                    SphereName = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sphere__4FFFED4FC9E116AF", x => x.SphereKey);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "project",
                columns: table => new
                {
                    StatusKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Status__096C98C36E3F51C6", x => x.StatusKey);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "hr",
                columns: table => new
                {
                    UserKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UserTypeKey = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    UserName = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    Rating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__296ADCF14E90AAFB", x => x.UserKey);
                    table.ForeignKey(
                        name: "FK__User__UserTypeKe__5AEE82B9",
                        column: x => x.UserTypeKey,
                        principalSchema: "hr",
                        principalTable: "UserType",
                        principalColumn: "UserTypeKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectProduct",
                schema: "project",
                columns: table => new
                {
                    ProjectKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(maxLength: 100, nullable: true),
                    ProjectTypeKey = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjectP__C048AC94B07BE9AB", x => x.ProjectKey);
                    table.ForeignKey(
                        name: "FK__ProjectPr__Proje__6EF57B66",
                        column: x => x.ProjectTypeKey,
                        principalSchema: "project",
                        principalTable: "ProjectType",
                        principalColumn: "ProjectTypeKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "hr",
                columns: table => new
                {
                    UserKey = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Phone_Number = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Age = table.Column<int>(nullable: true),
                    GenderKey = table.Column<int>(nullable: true),
                    CountryKey = table.Column<int>(nullable: true),
                    Address = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Person__CountryK__68487DD7",
                        column: x => x.CountryKey,
                        principalSchema: "core",
                        principalTable: "Country",
                        principalColumn: "CountryKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Person__GenderKe__6754599E",
                        column: x => x.GenderKey,
                        principalSchema: "hr",
                        principalTable: "Gender",
                        principalColumn: "GenderKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Person__UserKey__66603565",
                        column: x => x.UserKey,
                        principalSchema: "hr",
                        principalTable: "User",
                        principalColumn: "UserKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "project",
                columns: table => new
                {
                    ProjectKey = table.Column<int>(nullable: true),
                    UserKey = table.Column<int>(nullable: true),
                    StartDateKey = table.Column<int>(nullable: true),
                    StatusKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Project__Project__02FC7413",
                        column: x => x.ProjectKey,
                        principalSchema: "project",
                        principalTable: "ProjectProduct",
                        principalColumn: "ProjectKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Project__StatusK__04E4BC85",
                        column: x => x.StatusKey,
                        principalSchema: "project",
                        principalTable: "Status",
                        principalColumn: "StatusKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Project__UserKey__03F0984C",
                        column: x => x.UserKey,
                        principalSchema: "hr",
                        principalTable: "User",
                        principalColumn: "UserKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSphere",
                schema: "project",
                columns: table => new
                {
                    ProjectKey = table.Column<int>(nullable: true),
                    SphereKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__ProjectSp__Proje__7A672E12",
                        column: x => x.ProjectKey,
                        principalSchema: "project",
                        principalTable: "ProjectProduct",
                        principalColumn: "ProjectKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ProjectSp__Spher__7B5B524B",
                        column: x => x.SphereKey,
                        principalSchema: "project",
                        principalTable: "Sphere",
                        principalColumn: "SphereKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_CountryKey",
                schema: "hr",
                table: "Person",
                column: "CountryKey");

            migrationBuilder.CreateIndex(
                name: "IX_Person_GenderKey",
                schema: "hr",
                table: "Person",
                column: "GenderKey");

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserKey",
                schema: "hr",
                table: "Person",
                column: "UserKey");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeKey",
                schema: "hr",
                table: "User",
                column: "UserTypeKey");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectKey",
                schema: "project",
                table: "Project",
                column: "ProjectKey");

            migrationBuilder.CreateIndex(
                name: "IX_Project_StatusKey",
                schema: "project",
                table: "Project",
                column: "StatusKey");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserKey",
                schema: "project",
                table: "Project",
                column: "UserKey");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProduct_ProjectTypeKey",
                schema: "project",
                table: "ProjectProduct",
                column: "ProjectTypeKey");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSphere_ProjectKey",
                schema: "project",
                table: "ProjectSphere",
                column: "ProjectKey");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSphere_SphereKey",
                schema: "project",
                table: "ProjectSphere",
                column: "SphereKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "project");

            migrationBuilder.DropTable(
                name: "ProjectSphere",
                schema: "project");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Gender",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "project");

            migrationBuilder.DropTable(
                name: "User",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "ProjectProduct",
                schema: "project");

            migrationBuilder.DropTable(
                name: "Sphere",
                schema: "project");

            migrationBuilder.DropTable(
                name: "UserType",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "ProjectType",
                schema: "project");
        }
    }
}
