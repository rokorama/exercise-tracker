﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using exercisetracker.Data;

#nullable disable

namespace exercisetracker.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230917152504_Fix-wrong-child-on-WorkoutSession")]
    partial class FixwrongchildonWorkoutSession
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("exercisetracker.Models.RunInstance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Outside")
                        .HasColumnType("bit");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("WarmupTime")
                        .HasColumnType("time");

                    b.Property<Guid?>("WorkoutSessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutSessionId");

                    b.ToTable("RunningExercises");
                });

            modelBuilder.Entity("exercisetracker.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("exercisetracker.Models.WeightExercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnMachine")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WeightAscending")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("WeightExercises");
                });

            modelBuilder.Entity("exercisetracker.Models.WeightExerciseInstance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Success")
                        .HasColumnType("bit");

                    b.Property<Guid?>("WorkoutSessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutSessionId");

                    b.ToTable("WeightExerciseInstance");
                });

            modelBuilder.Entity("exercisetracker.Models.WeightExerciseSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<Guid?>("WeightExerciseInstanceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WeightExerciseInstanceId");

                    b.ToTable("ExerciseSets");
                });

            modelBuilder.Entity("exercisetracker.Models.WorkoutSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WorkoutSessions");
                });

            modelBuilder.Entity("exercisetracker.Models.RunInstance", b =>
                {
                    b.HasOne("exercisetracker.Models.WorkoutSession", null)
                        .WithMany("Runs")
                        .HasForeignKey("WorkoutSessionId");
                });

            modelBuilder.Entity("exercisetracker.Models.WeightExerciseInstance", b =>
                {
                    b.HasOne("exercisetracker.Models.WorkoutSession", null)
                        .WithMany("WeightExercises")
                        .HasForeignKey("WorkoutSessionId");
                });

            modelBuilder.Entity("exercisetracker.Models.WeightExerciseSet", b =>
                {
                    b.HasOne("exercisetracker.Models.WeightExerciseInstance", null)
                        .WithMany("Sets")
                        .HasForeignKey("WeightExerciseInstanceId");
                });

            modelBuilder.Entity("exercisetracker.Models.WorkoutSession", b =>
                {
                    b.HasOne("exercisetracker.Models.User", null)
                        .WithMany("WorkoutSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("exercisetracker.Models.User", b =>
                {
                    b.Navigation("WorkoutSessions");
                });

            modelBuilder.Entity("exercisetracker.Models.WeightExerciseInstance", b =>
                {
                    b.Navigation("Sets");
                });

            modelBuilder.Entity("exercisetracker.Models.WorkoutSession", b =>
                {
                    b.Navigation("Runs");

                    b.Navigation("WeightExercises");
                });
#pragma warning restore 612, 618
        }
    }
}