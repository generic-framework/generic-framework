﻿// <auto-generated />
using System;
using Main.Server.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Main.Server.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Main.Server.Core.Entities.DepartmentEntities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.ProductEntities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.ProjectEntities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ProjectType")
                        .HasColumnType("int");

                    b.Property<int>("ProjectTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.ProjectEntities.ProjectUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectUsers");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.RoleEntities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.TaskEntities.TaskEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeparmentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DevelopmentCompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IssueTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MainTaskId")
                        .HasColumnType("int");

                    b.Property<int?>("PriorityTypes")
                        .HasColumnType("int");

                    b.Property<int?>("PriortyTypesId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProcessingDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int?>("SubjectTypes")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectTypesId")
                        .HasColumnType("int");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("TaskStatuId")
                        .HasColumnType("int");

                    b.Property<string>("TaskTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MainTaskId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TaskStatuId");

                    b.ToTable("TaskEntities");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.TaskEntities.TaskStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("StatusPosition")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TaskStatus");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.TaskEntities.TaskUser", b =>
                {
                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TaskId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskUsers");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.TaskFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskFiles");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.UserEntities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.ProjectEntities.ProjectUser", b =>
                {
                    b.HasOne("Main.Server.Core.Entities.ProjectEntities.Project", "Project")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Main.Server.Core.Entities.UserEntities.User", "User")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("UserId");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.TaskEntities.TaskEntity", b =>
                {
                    b.HasOne("Main.Server.Core.Entities.TaskEntities.TaskEntity", "MainTask")
                        .WithMany()
                        .HasForeignKey("MainTaskId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Main.Server.Core.Entities.ProjectEntities.Project", "Project")
                        .WithMany("ProjectTasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Main.Server.Core.Entities.TaskEntities.TaskStatusEntity", "TaskStatus")
                        .WithMany("TaskEntities")
                        .HasForeignKey("TaskStatuId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("MainTask");

                    b.Navigation("Project");

                    b.Navigation("TaskStatus");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.TaskEntities.TaskUser", b =>
                {
                    b.HasOne("Main.Server.Core.Entities.TaskEntities.TaskEntity", "Task")
                        .WithMany("TaskUsers")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Main.Server.Core.Entities.UserEntities.User", "User")
                        .WithMany("TaskUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.TaskFile", b =>
                {
                    b.HasOne("Main.Server.Core.Entities.TaskEntities.TaskEntity", "TaskEntity")
                        .WithMany("Files")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("TaskEntity");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.UserEntities.User", b =>
                {
                    b.HasOne("Main.Server.Core.Entities.DepartmentEntities.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Main.Server.Core.Entities.RoleEntities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.DepartmentEntities.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.ProjectEntities.Project", b =>
                {
                    b.Navigation("ProjectTasks");

                    b.Navigation("ProjectUsers");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.RoleEntities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.TaskEntities.TaskEntity", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("TaskUsers");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.TaskEntities.TaskStatusEntity", b =>
                {
                    b.Navigation("TaskEntities");
                });

            modelBuilder.Entity("Main.Server.Core.Entities.UserEntities.User", b =>
                {
                    b.Navigation("ProjectUsers");

                    b.Navigation("TaskUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
