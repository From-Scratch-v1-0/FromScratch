using FS_DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace FS_DAL.Context
{
    public class FSContext : IdentityDbContext
    {

        public FSContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectProduct> ProjectProduct { get; set; }
        public virtual DbSet<ProjectSphere> ProjectSphere { get; set; }
        public virtual DbSet<ProjectType> ProjectType { get; set; }
        public virtual DbSet<Sphere> Sphere { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryKey)
                    .HasName("PK__Country__B92CEBD450B06B79");

                entity.ToTable("Country", "core");

                entity.Property(e => e.CountryName).HasMaxLength(100);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.GenderKey)
                    .HasName("PK__Gender__44C092CDFD0FE67E");

                entity.ToTable("Gender", "hr");

                entity.Property(e => e.GenderName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Person", "hr");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("Phone_Number")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CountryKey)
                    .HasConstraintName("FK__Person__CountryK__68487DD7");

                entity.HasOne(d => d.GenderKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.GenderKey)
                    .HasConstraintName("FK__Person__GenderKe__6754599E");

                entity.HasOne(d => d.UserKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.UserKey)
                    .HasConstraintName("FK__Person__UserKey__66603565");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Project", "project");

                entity.HasOne(d => d.ProjectKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ProjectKey)
                    .HasConstraintName("FK__Project__Project__02FC7413");

                entity.HasOne(d => d.StatusKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.StatusKey)
                    .HasConstraintName("FK__Project__StatusK__04E4BC85");

                entity.HasOne(d => d.UserKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.UserKey)
                    .HasConstraintName("FK__Project__UserKey__03F0984C");
            });

            modelBuilder.Entity<ProjectProduct>(entity =>
            {
                entity.HasKey(e => e.ProjectKey)
                    .HasName("PK__ProjectP__C048AC94B07BE9AB");

                entity.ToTable("ProjectProduct", "project");

                entity.Property(e => e.ProjectName).HasMaxLength(100);

                entity.HasOne(d => d.ProjectTypeKeyNavigation)
                    .WithMany(p => p.ProjectProduct)
                    .HasForeignKey(d => d.ProjectTypeKey)
                    .HasConstraintName("FK__ProjectPr__Proje__6EF57B66");
            });

            modelBuilder.Entity<ProjectSphere>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProjectSphere", "project");

                entity.HasOne(d => d.ProjectKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ProjectKey)
                    .HasConstraintName("FK__ProjectSp__Proje__7A672E12");

                entity.HasOne(d => d.SphereKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SphereKey)
                    .HasConstraintName("FK__ProjectSp__Spher__7B5B524B");
            });

            modelBuilder.Entity<ProjectType>(entity =>
            {
                entity.HasKey(e => e.ProjectTypeKey)
                    .HasName("PK__ProjectT__4BF49607019B42CF");

                entity.ToTable("ProjectType", "project");

                entity.Property(e => e.ProjectTypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<Sphere>(entity =>
            {
                entity.HasKey(e => e.SphereKey)
                    .HasName("PK__Sphere__4FFFED4FC9E116AF");

                entity.ToTable("Sphere", "project");

                entity.Property(e => e.SphereKey).ValueGeneratedNever();

                entity.Property(e => e.SphereName).HasMaxLength(200);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.StatusKey)
                    .HasName("PK__Status__096C98C36E3F51C6");

                entity.ToTable("Status", "project");

                entity.Property(e => e.StatusName).HasMaxLength(200);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.UserTypeKey)
                    .HasName("PK__UserType__8002849E07A2BA12");

                entity.ToTable("UserType", "hr");

                entity.Property(e => e.UserTypeName).HasMaxLength(100);

                entity.HasMany(d => d.User)
                    .WithOne(p => p.UserTypeKeyNavigation)
                    .HasForeignKey(d => d.UserTypeKey)
                    .HasConstraintName("FK__User__UserTypeKe__5AEE82B9");
            });


            modelBuilder.Seed();
        }
    }
}
