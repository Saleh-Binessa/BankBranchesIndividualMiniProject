﻿// <auto-generated />
using BankBranchesIndividualMiniProject.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankBranchesIndividualMiniProject.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20240423131357_AddEmployees")]
    partial class AddEmployees
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("BankBranchesIndividualMiniProject.Models.BankBranch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BranchManager")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BranchId");

                    b.ToTable("BankBranches");

                    b.HasData(
                        new
                        {
                            BranchId = 1,
                            BranchManager = "Omar Ali",
                            EmployeeCount = 35,
                            Location = "https://maps.app.goo.gl/3LTYnjuK7YzeyAD46",
                            Name = "Head office"
                        },
                        new
                        {
                            BranchId = 2,
                            BranchManager = "Majid Al-Shuwaiee",
                            EmployeeCount = 12,
                            Location = "https://maps.app.goo.gl/3hvBso457K9ZrReNA",
                            Name = "Avenues"
                        });
                });

            modelBuilder.Entity("BankBranchesIndividualMiniProject.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CivilId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("WorkplaceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkplaceId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CivilId = "299022600558",
                            Name = "Saleh",
                            Position = "DP1",
                            WorkplaceId = 1
                        },
                        new
                        {
                            Id = 2,
                            CivilId = "299072600558",
                            Name = "Ahmad",
                            Position = "DP2",
                            WorkplaceId = 2
                        });
                });

            modelBuilder.Entity("BankBranchesIndividualMiniProject.Models.Employee", b =>
                {
                    b.HasOne("BankBranchesIndividualMiniProject.Models.BankBranch", "Workplace")
                        .WithMany("Employees")
                        .HasForeignKey("WorkplaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workplace");
                });

            modelBuilder.Entity("BankBranchesIndividualMiniProject.Models.BankBranch", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
