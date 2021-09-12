﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimbirSquize.Data.Testing;

namespace SimbirSquize.Migrations.Testing
{
    [DbContext(typeof(TestingContext))]
    [Migration("20210912055322_ScoresChangeModelModel")]
    partial class ScoresChangeModelModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("SimbirSquize.Data.Score", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("char(36)");

                    b.Property<double>("RightCount")
                        .HasColumnType("double");

                    b.Property<int>("ScoreId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CourseId");

                    b.ToTable("scores");
                });

            modelBuilder.Entity("SimbirSquize.Data.Testing.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("topics");
                });

            modelBuilder.Entity("SimbirSquize.Data.Testing.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("lessons");
                });

            modelBuilder.Entity("SimbirSquize.Data.Testing.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("char(36)");

                    b.Property<string>("QuestionText")
                        .HasColumnType("longtext");

                    b.Property<string>("RightAnswerId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("SimbirSquize.Data.Testing.TestAnswer", b =>
                {
                    b.Property<Guid>("QuestionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("TestId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("QuestionId", "Id");

                    b.HasIndex("TestId");

                    b.ToTable("test_answers");
                });

            modelBuilder.Entity("SimbirSquize.Data.Testing.Lesson", b =>
                {
                    b.HasOne("SimbirSquize.Data.Testing.Course", null)
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimbirSquize.Data.Testing.Question", b =>
                {
                    b.HasOne("SimbirSquize.Data.Testing.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SimbirSquize.Data.Testing.TestAnswer", b =>
                {
                    b.HasOne("SimbirSquize.Data.Testing.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("TestId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("SimbirSquize.Data.Testing.Course", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("SimbirSquize.Data.Testing.Question", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
