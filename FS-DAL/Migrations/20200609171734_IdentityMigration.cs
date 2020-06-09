using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FS_DAL.Migrations
{
    public partial class IdentityMigration : Migration
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    UserTypeKey = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    Rating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "hr",
                columns: table => new
                {
                    UserKey = table.Column<string>(nullable: true),
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
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "project",
                columns: table => new
                {
                    ProjectKey = table.Column<int>(nullable: true),
                    UserKey = table.Column<string>(nullable: true),
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
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTypeKey",
                table: "AspNetUsers",
                column: "UserTypeKey");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "AspNetRoles");

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
                name: "AspNetUsers");

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
