﻿// <auto-generated />
using System;
using Calculator.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Calculator.Migrations
{
    [DbContext(typeof(CalculatorDbContext))]
    [Migration("20191026185437_CreateReportTable")]
    partial class CreateReportTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Calculator.Models.Method", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("INSERT_DATE");

                    b.HasKey("Id");

                    b.ToTable("Methods");
                });

            modelBuilder.Entity("Calculator.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("INSERT_DATE");

                    b.Property<string>("VALUE");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
