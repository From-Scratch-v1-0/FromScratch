﻿// <auto-generated />
using System;
using FS_DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FS_DAL.Migrations
{
    [DbContext(typeof(FSContext))]
    [Migration("20200611051110_SandrosMigration")]
    partial class SandrosMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FS_DAL.Entities.Country", b =>
                {
                    b.Property<int>("CountryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("CountryKey")
                        .HasName("PK__Country__B92CEBD450B06B79");

                    b.ToTable("Country","core");
                });

            modelBuilder.Entity("FS_DAL.Entities.Gender", b =>
                {
                    b.Property<int>("GenderKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderName")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("GenderKey")
                        .HasName("PK__Gender__44C092CDFD0FE67E");

                    b.ToTable("Gender","hr");
                });

            modelBuilder.Entity("FS_DAL.Entities.Person", b =>
                {
                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("CountryKey")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("GenderKey")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("Phone_Number")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("UserKey")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("CountryKey");

                    b.HasIndex("GenderKey");

                    b.HasIndex("UserKey");

                    b.ToTable("Person","hr");
                });

            modelBuilder.Entity("FS_DAL.Entities.Project", b =>
                {
                    b.Property<int?>("ProjectKey")
                        .HasColumnType("int");

                    b.Property<int?>("StartDateKey")
                        .HasColumnType("int");

                    b.Property<int?>("StatusKey")
                        .HasColumnType("int");

                    b.Property<string>("UserKey")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("ProjectKey");

                    b.HasIndex("StatusKey");

                    b.HasIndex("UserKey");

                    b.ToTable("Project","project");
                });

            modelBuilder.Entity("FS_DAL.Entities.ProjectProduct", b =>
                {
                    b.Property<int>("ProjectKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("ProjectTypeKey")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ProjectKey")
                        .HasName("PK__ProjectP__C048AC94B07BE9AB");

                    b.HasIndex("ProjectTypeKey");

                    b.ToTable("ProjectProduct","project");
                });

            modelBuilder.Entity("FS_DAL.Entities.ProjectSphere", b =>
                {
                    b.Property<int?>("ProjectKey")
                        .HasColumnType("int");

                    b.Property<int?>("SphereKey")
                        .HasColumnType("int");

                    b.HasIndex("ProjectKey");

                    b.HasIndex("SphereKey");

                    b.ToTable("ProjectSphere","project");
                });

            modelBuilder.Entity("FS_DAL.Entities.ProjectType", b =>
                {
                    b.Property<int>("ProjectTypeKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProjectTypeName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ProjectTypeKey")
                        .HasName("PK__ProjectT__4BF49607019B42CF");

                    b.ToTable("ProjectType","project");
                });

            modelBuilder.Entity("FS_DAL.Entities.Sphere", b =>
                {
                    b.Property<int>("SphereKey")
                        .HasColumnType("int");

                    b.Property<string>("SphereName")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("SphereKey")
                        .HasName("PK__Sphere__4FFFED4FC9E116AF");

                    b.ToTable("Sphere","project");
                });

            modelBuilder.Entity("FS_DAL.Entities.Status", b =>
                {
                    b.Property<int>("StatusKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("StatusKey")
                        .HasName("PK__Status__096C98C36E3F51C6");

                    b.ToTable("Status","project");
                });

            modelBuilder.Entity("FS_DAL.Entities.UserType", b =>
                {
                    b.Property<int>("UserTypeKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserTypeName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("UserTypeKey")
                        .HasName("PK__UserType__8002849E07A2BA12");

                    b.ToTable("UserType","hr");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FS_DAL.Entities.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("UserTypeKey")
                        .HasColumnType("int");

                    b.HasIndex("UserTypeKey");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("FS_DAL.Entities.Person", b =>
                {
                    b.HasOne("FS_DAL.Entities.Country", "CountryKeyNavigation")
                        .WithMany()
                        .HasForeignKey("CountryKey")
                        .HasConstraintName("FK__Person__CountryK__68487DD7");

                    b.HasOne("FS_DAL.Entities.Gender", "GenderKeyNavigation")
                        .WithMany()
                        .HasForeignKey("GenderKey")
                        .HasConstraintName("FK__Person__GenderKe__6754599E");

                    b.HasOne("FS_DAL.Entities.User", "UserKeyNavigation")
                        .WithMany()
                        .HasForeignKey("UserKey")
                        .HasConstraintName("FK__Person__UserKey__66603565");
                });

            modelBuilder.Entity("FS_DAL.Entities.Project", b =>
                {
                    b.HasOne("FS_DAL.Entities.ProjectProduct", "ProjectKeyNavigation")
                        .WithMany()
                        .HasForeignKey("ProjectKey")
                        .HasConstraintName("FK__Project__Project__02FC7413");

                    b.HasOne("FS_DAL.Entities.Status", "StatusKeyNavigation")
                        .WithMany()
                        .HasForeignKey("StatusKey")
                        .HasConstraintName("FK__Project__StatusK__04E4BC85");

                    b.HasOne("FS_DAL.Entities.User", "UserKeyNavigation")
                        .WithMany()
                        .HasForeignKey("UserKey")
                        .HasConstraintName("FK__Project__UserKey__03F0984C");
                });

            modelBuilder.Entity("FS_DAL.Entities.ProjectProduct", b =>
                {
                    b.HasOne("FS_DAL.Entities.ProjectType", "ProjectTypeKeyNavigation")
                        .WithMany("ProjectProduct")
                        .HasForeignKey("ProjectTypeKey")
                        .HasConstraintName("FK__ProjectPr__Proje__6EF57B66");
                });

            modelBuilder.Entity("FS_DAL.Entities.ProjectSphere", b =>
                {
                    b.HasOne("FS_DAL.Entities.ProjectProduct", "ProjectKeyNavigation")
                        .WithMany()
                        .HasForeignKey("ProjectKey")
                        .HasConstraintName("FK__ProjectSp__Proje__7A672E12");

                    b.HasOne("FS_DAL.Entities.Sphere", "SphereKeyNavigation")
                        .WithMany()
                        .HasForeignKey("SphereKey")
                        .HasConstraintName("FK__ProjectSp__Spher__7B5B524B");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FS_DAL.Entities.User", b =>
                {
                    b.HasOne("FS_DAL.Entities.UserType", "UserTypeKeyNavigation")
                        .WithMany("User")
                        .HasForeignKey("UserTypeKey")
                        .HasConstraintName("FK__User__UserTypeKe__5AEE82B9");
                });
#pragma warning restore 612, 618
        }
    }
}
