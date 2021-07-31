﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ScalableTeaching.Data;

namespace ScalableTeaching.Migrations
{
    [DbContext(typeof(VmDeploymentContext))]
    [Migration("20210731062659_usersNames")]
    partial class usersNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ScalableTeaching.Models.Course", b =>
                {
                    b.Property<Guid>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SDUCourseID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShortCourseName")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)")
                        .HasComment("Should be between 3 and 6 characters");

                    b.Property<string>("UserUsername")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("The user responsible for the course i.e. the user that can make machines associated with the course");

                    b.HasKey("CourseID");

                    b.HasIndex("UserUsername");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ScalableTeaching.Models.Group", b =>
                {
                    b.Property<Guid>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseID")
                        .HasColumnType("uuid");

                    b.Property<int>("GroupIndex")
                        .HasColumnType("integer");

                    b.Property<string>("GroupName")
                        .HasColumnType("text");

                    b.HasKey("GroupID");

                    b.HasIndex("CourseID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ScalableTeaching.Models.GroupAssignment", b =>
                {
                    b.Property<Guid>("GroupID")
                        .HasColumnType("uuid");

                    b.Property<string>("UserUsername")
                        .HasColumnType("text");

                    b.HasKey("GroupID", "UserUsername");

                    b.HasIndex("UserUsername");

                    b.ToTable("GroupAssignments");
                });

            modelBuilder.Entity("ScalableTeaching.Models.LocalForward", b =>
                {
                    b.Property<Guid>("MachineID")
                        .HasColumnType("uuid");

                    b.Property<int>("PortNumber")
                        .HasColumnType("integer");

                    b.HasKey("MachineID", "PortNumber");

                    b.ToTable("LocalForwards");
                });

            modelBuilder.Entity("ScalableTeaching.Models.Machine", b =>
                {
                    b.Property<Guid>("MachineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseID")
                        .HasColumnType("uuid");

                    b.Property<string>("HostName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserUsername")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MachineID");

                    b.HasIndex("CourseID");

                    b.HasIndex("UserUsername");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("ScalableTeaching.Models.MachineAssignment", b =>
                {
                    b.Property<Guid>("MachineID")
                        .HasColumnType("uuid");

                    b.Property<string>("UserUsername")
                        .HasColumnType("text");

                    b.Property<Guid?>("GroupID")
                        .HasColumnType("uuid");

                    b.Property<string>("OneTimePassword")
                        .HasColumnType("text");

                    b.HasKey("MachineID", "UserUsername");

                    b.HasIndex("GroupID");

                    b.HasIndex("UserUsername");

                    b.ToTable("MachineAssignments");
                });

            modelBuilder.Entity("ScalableTeaching.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<int>("AccountType")
                        .HasColumnType("integer");

                    b.Property<string>("GeneralName")
                        .HasColumnType("text");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("UserPrivateKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ScalableTeaching.Models.Course", b =>
                {
                    b.HasOne("ScalableTeaching.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ScalableTeaching.Models.Group", b =>
                {
                    b.HasOne("ScalableTeaching.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ScalableTeaching.Models.GroupAssignment", b =>
                {
                    b.HasOne("ScalableTeaching.Models.Group", "Group")
                        .WithMany("GroupAssignments")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScalableTeaching.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ScalableTeaching.Models.LocalForward", b =>
                {
                    b.HasOne("ScalableTeaching.Models.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("ScalableTeaching.Models.Machine", b =>
                {
                    b.HasOne("ScalableTeaching.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScalableTeaching.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ScalableTeaching.Models.MachineAssignment", b =>
                {
                    b.HasOne("ScalableTeaching.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupID");

                    b.HasOne("ScalableTeaching.Models.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScalableTeaching.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Machine");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ScalableTeaching.Models.Group", b =>
                {
                    b.Navigation("GroupAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
