﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senseition.Datas;

namespace Senseition.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210329175225_ReCreateForeignkey")]
    partial class ReCreateForeignkey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Senseition.Models.DataModels.Course", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("course_name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Senseition.Models.DataModels.Faculty", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("faculty_name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("logo_url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("Senseition.Models.DataModels.Major", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("faculty_id")
                        .HasColumnType("bigint");

                    b.Property<string>("major_logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("major_name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("id");

                    b.HasIndex("faculty_id");

                    b.ToTable("Major");
                });

            modelBuilder.Entity("Senseition.Models.DataModels.Survey", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("answer_question1")
                        .HasColumnType("tinyint");

                    b.Property<byte>("answer_question2")
                        .HasColumnType("tinyint");

                    b.Property<byte>("answer_question3")
                        .HasColumnType("tinyint");

                    b.Property<byte>("answer_question4")
                        .HasColumnType("tinyint");

                    b.Property<byte>("answer_question5")
                        .HasColumnType("tinyint");

                    b.HasKey("id");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("Senseition.Models.DataModels.Teacher", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("age")
                        .HasColumnType("tinyint");

                    b.Property<string>("biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("first_name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("last_name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("major_id")
                        .HasColumnType("bigint");

                    b.Property<string>("picture_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("position")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<byte>("rate")
                        .HasColumnType("tinyint");

                    b.HasKey("id");

                    b.HasIndex("major_id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("Senseition.Models.DataModels.TeacherCourse", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("course_id")
                        .HasColumnType("bigint");

                    b.Property<long>("teacher_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("course_id");

                    b.HasIndex("teacher_id");

                    b.ToTable("TeacherCourse");
                });

            modelBuilder.Entity("Senseition.Models.DataModels.UserReview", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("average_rate")
                        .HasColumnType("real");

                    b.Property<long>("course_id")
                        .HasColumnType("bigint");

                    b.Property<string>("course_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("like_no")
                        .HasColumnType("int");

                    b.Property<string>("review_message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("semeter")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<long>("survey_id")
                        .HasColumnType("bigint");

                    b.Property<string>("teacher_first_name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("teacher_id")
                        .HasColumnType("bigint");

                    b.Property<string>("teacher_last_name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("user_first_name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.Property<string>("user_last_name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("id");

                    b.HasIndex("course_id");

                    b.HasIndex("survey_id");

                    b.HasIndex("teacher_id");

                    b.HasIndex("user_id");

                    b.ToTable("UserReview");
                });

            modelBuilder.Entity("Senseition.Models.DataModels.Users", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("first_name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("last_name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("user_picture_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Senseition.Models.DataModels.Major", b =>
                {
                    b.HasOne("Senseition.Models.DataModels.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("faculty_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Senseition.Models.DataModels.Teacher", b =>
                {
                    b.HasOne("Senseition.Models.DataModels.Major", "Major")
                        .WithMany()
                        .HasForeignKey("major_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Senseition.Models.DataModels.TeacherCourse", b =>
                {
                    b.HasOne("Senseition.Models.DataModels.Course", "Course")
                        .WithMany()
                        .HasForeignKey("course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Senseition.Models.DataModels.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("teacher_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Senseition.Models.DataModels.UserReview", b =>
                {
                    b.HasOne("Senseition.Models.DataModels.Course", "Course")
                        .WithMany()
                        .HasForeignKey("course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Senseition.Models.DataModels.Survey", "Survey")
                        .WithMany()
                        .HasForeignKey("survey_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Senseition.Models.DataModels.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("teacher_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Senseition.Models.DataModels.Users", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}