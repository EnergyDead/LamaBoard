﻿// <auto-generated />
using System;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220409072608_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Boards", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Prioryty")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectsId");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("Domain.Entities.Projects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreaterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreaterId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Domain.Entities.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BoardsId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoardsId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Domain.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TasksUsers", b =>
                {
                    b.Property<int>("TasksId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("TasksId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("TasksUsers");
                });

            modelBuilder.Entity("Domain.Entities.Boards", b =>
                {
                    b.HasOne("Domain.Entities.Projects", null)
                        .WithMany("Boards")
                        .HasForeignKey("ProjectsId");
                });

            modelBuilder.Entity("Domain.Entities.Projects", b =>
                {
                    b.HasOne("Domain.Entities.Users", "Creater")
                        .WithMany("Projects")
                        .HasForeignKey("CreaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creater");
                });

            modelBuilder.Entity("Domain.Entities.Tasks", b =>
                {
                    b.HasOne("Domain.Entities.Boards", null)
                        .WithMany("Tasks")
                        .HasForeignKey("BoardsId");
                });

            modelBuilder.Entity("TasksUsers", b =>
                {
                    b.HasOne("Domain.Entities.Tasks", null)
                        .WithMany()
                        .HasForeignKey("TasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Users", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Boards", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Domain.Entities.Projects", b =>
                {
                    b.Navigation("Boards");
                });

            modelBuilder.Entity("Domain.Entities.Users", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
