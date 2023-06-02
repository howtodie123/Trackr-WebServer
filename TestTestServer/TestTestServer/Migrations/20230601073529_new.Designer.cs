﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTestServer.Data;

#nullable disable

namespace TestTestServer.Migrations
{
    [DbContext(typeof(APIData))]
    [Migration("20230601073529_new")]
    partial class @new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestTestServer.Models.Ad", b =>
                {
                    b.Property<int>("AdID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdID"));

                    b.Property<string>("AdAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("TestTestServer.Models.Customer", b =>
                {
                    b.Property<int>("CusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CusID"));

                    b.Property<string>("CusAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CusAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CusBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CusDateRegister")
                        .HasColumnType("datetime2");

                    b.Property<string>("CusName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CusPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CusPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CusID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("TestTestServer.Models.DeliveryMan", b =>
                {
                    b.Property<int>("ManID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManID"));

                    b.Property<string>("ManAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManID");

                    b.ToTable("DeliveryMan");
                });

            modelBuilder.Entity("TestTestServer.Models.Parcel", b =>
                {
                    b.Property<int>("ParID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParID"));

                    b.Property<int>("CusID")
                        .HasColumnType("int");

                    b.Property<int>("ManID")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ParDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ParDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Realtime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParID");

                    b.ToTable("Parcel");
                });
#pragma warning restore 612, 618
        }
    }
}
