﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using banking.Data;

#nullable disable

namespace banking_system.Migrations
{
    [DbContext(typeof(BankingDbContext))]
    [Migration("20241117083039_birthdateDateonly")]
    partial class birthdateDateonly
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("banking.Model.BankAccount", b =>
                {
                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssociatedPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,3)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("HolderName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Number");

                    b.ToTable("BankAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
