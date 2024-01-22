﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebatecnicaNASA_JJH.Context;

#nullable disable

namespace PruebatecnicaNASA_JJH.Migrations
{
    [DbContext(typeof(AsteroidContext))]
    partial class AsteroidContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PruebatecnicaNASA_JJH.Entities.AsteroidEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("EstimatedDiameter")
                        .HasColumnType("float")
                        .HasColumnName("Diameter");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Planet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Velocity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Asteroid", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
