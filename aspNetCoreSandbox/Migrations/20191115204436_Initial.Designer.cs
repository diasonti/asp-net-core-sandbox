﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using aspNetCoreSandbox.Models;

namespace aspNetCoreSandbox.Migrations
{
    [DbContext(typeof(SandboxDbContext))]
    [Migration("20191115204436_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("aspNetCoreSandbox.Models.Entities.Class", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<long?>("CourseId")
                        .HasColumnName("course_id")
                        .HasColumnType("bigint");

                    b.Property<string>("Topic")
                        .HasColumnName("topic")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("class");
                });

            modelBuilder.Entity("aspNetCoreSandbox.Models.Entities.Course", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("course");
                });

            modelBuilder.Entity("aspNetCoreSandbox.Models.Entities.IndividualTask", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<long?>("ClassId")
                        .HasColumnName("class_id")
                        .HasColumnType("bigint");

                    b.Property<long?>("StudentId")
                        .HasColumnName("student_id")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnName("text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("individual_task");
                });

            modelBuilder.Entity("aspNetCoreSandbox.Models.Entities.IndividualTaskGrade", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("Grade")
                        .HasColumnName("grade")
                        .HasColumnType("integer");

                    b.Property<long>("TaskId")
                        .HasColumnName("task_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TaskId")
                        .IsUnique();

                    b.ToTable("individual_task_grade");
                });

            modelBuilder.Entity("aspNetCoreSandbox.Models.Entities.Task", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<long?>("ClassId")
                        .HasColumnName("class_id")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnName("text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("task");
                });

            modelBuilder.Entity("aspNetCoreSandbox.Models.Entities.TaskGrade", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("Grade")
                        .HasColumnName("grade")
                        .HasColumnType("integer");

                    b.Property<long?>("TaskId")
                        .HasColumnName("task_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("task_grade");
                });

            modelBuilder.Entity("aspNetCoreSandbox.Models.Entities.UserAccount", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnName("role")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("user_account");
                });

            modelBuilder.Entity("aspNetCoreSandbox.Models.Entities.Utils.UserAccountToCourseLink", b =>
                {
                    b.Property<long>("UserAccountId")
                        .HasColumnName("user_account_id")
                        .HasColumnType("bigint");

                    b.Property<long>("CourseId")
                        .HasColumnName("course_id")
                        .HasColumnType("bigint");

                    b.HasKey("UserAccountId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("user_account_to_course_link");
                });

            modelBuilder.Entity("aspNetCoreSandbox.Models.Entities.Class", b =>
                {
                    b.HasOne("aspNetCoreSandbox.Models.Entities.Course", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("aspNetCoreSandbox.Models.Entities.IndividualTask", b =>
                {
                    b.HasOne("aspNetCoreSandbox.Models.Entities.Class", "Class")
                        .WithMany("IndividualTasks")
                        .HasForeignKey("ClassId");

                    b.HasOne("aspNetCoreSandbox.Models.Entities.Class", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("aspNetCoreSandbox.Models.Entities.IndividualTaskGrade", b =>
                {
                    b.HasOne("aspNetCoreSandbox.Models.Entities.IndividualTask", "Task")
                        .WithOne("Grade")
                        .HasForeignKey("aspNetCoreSandbox.Models.Entities.IndividualTaskGrade", "TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("aspNetCoreSandbox.Models.Entities.Task", b =>
                {
                    b.HasOne("aspNetCoreSandbox.Models.Entities.Class", "Class")
                        .WithMany("Tasks")
                        .HasForeignKey("ClassId");
                });

            modelBuilder.Entity("aspNetCoreSandbox.Models.Entities.TaskGrade", b =>
                {
                    b.HasOne("aspNetCoreSandbox.Models.Entities.Task", "Task")
                        .WithMany("Grades")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("aspNetCoreSandbox.Models.Entities.Utils.UserAccountToCourseLink", b =>
                {
                    b.HasOne("aspNetCoreSandbox.Models.Entities.Course", "Course")
                        .WithMany("StudentLinks")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("aspNetCoreSandbox.Models.Entities.UserAccount", "UserAccount")
                        .WithMany("CourseLinks")
                        .HasForeignKey("UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
