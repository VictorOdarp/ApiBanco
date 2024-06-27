﻿// <auto-generated />
using ApiBanco.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiBanco.Migrations
{
    [DbContext(typeof(AppBankDbContext))]
    [Migration("20240627014300_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ApiBanco.Models.AccountModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasColumnType("double");

                    b.Property<int>("HolderId")
                        .HasColumnType("int");

                    b.Property<double>("Limit")
                        .HasColumnType("double");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("HolderId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ApiBanco.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ApiBanco.Models.AccountModel", b =>
                {
                    b.HasOne("ApiBanco.Models.UserModel", "Holder")
                        .WithMany()
                        .HasForeignKey("HolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Holder");
                });
#pragma warning restore 612, 618
        }
    }
}
