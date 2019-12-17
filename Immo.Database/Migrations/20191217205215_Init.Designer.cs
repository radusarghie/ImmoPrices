﻿// <auto-generated />
using System;
using Immo.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Immo.Database.Migrations
{
    [DbContext(typeof(ImmoContext))]
    [Migration("20191217205215_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Immo.Domain.BusinessDomain.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Immo.Domain.BusinessDomain.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AddType")
                        .HasColumnType("int");

                    b.Property<int?>("BathroomNo")
                        .HasColumnType("int");

                    b.Property<double?>("Bedroom1Surface")
                        .HasColumnType("float");

                    b.Property<double?>("Bedroom2Surface")
                        .HasColumnType("float");

                    b.Property<double?>("Bedroom3Surface")
                        .HasColumnType("float");

                    b.Property<double?>("Bedroom4Surface")
                        .HasColumnType("float");

                    b.Property<int?>("BedroomsNo")
                        .HasColumnType("int");

                    b.Property<int?>("ConstructionYear")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EPC")
                        .HasColumnType("int");

                    b.Property<int?>("FloorNo")
                        .HasColumnType("int");

                    b.Property<int?>("Garrages")
                        .HasColumnType("int");

                    b.Property<double?>("GroundSurface")
                        .HasColumnType("float");

                    b.Property<bool?>("HasGarden")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasTerrace")
                        .HasColumnType("bit");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("LivableSurface")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParkingPlaces")
                        .HasColumnType("int");

                    b.Property<string>("Pictures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("PropertyType")
                        .HasColumnType("int");

                    b.Property<Guid?>("PropertyWebsiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TownId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PropertyWebsiteId");

                    b.HasIndex("TownId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Immo.Domain.BusinessDomain.PropertyWebsite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsitePropertyUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsiteRootUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PropertyWebsites");
                });

            modelBuilder.Entity("Immo.Domain.BusinessDomain.Province", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("Immo.Domain.BusinessDomain.Search", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("MaxPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("MaxRoomsNo")
                        .HasColumnType("int");

                    b.Property<decimal?>("MinPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("MinRoomsNo")
                        .HasColumnType("int");

                    b.Property<int?>("PropertyType")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Searches");
                });

            modelBuilder.Entity("Immo.Domain.BusinessDomain.SearchLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SearchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TownId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SearchId");

                    b.HasIndex("TownId");

                    b.ToTable("SearchLocations");
                });

            modelBuilder.Entity("Immo.Domain.BusinessDomain.Town", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProvinceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("Immo.Domain.BusinessDomain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Immo.Domain.BusinessDomain.Property", b =>
                {
                    b.HasOne("Immo.Domain.BusinessDomain.PropertyWebsite", "PropertyWebsite")
                        .WithMany()
                        .HasForeignKey("PropertyWebsiteId");

                    b.HasOne("Immo.Domain.BusinessDomain.Town", "Town")
                        .WithMany()
                        .HasForeignKey("TownId");
                });

            modelBuilder.Entity("Immo.Domain.BusinessDomain.Province", b =>
                {
                    b.HasOne("Immo.Domain.BusinessDomain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Immo.Domain.BusinessDomain.Search", b =>
                {
                    b.HasOne("Immo.Domain.BusinessDomain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Immo.Domain.BusinessDomain.SearchLocation", b =>
                {
                    b.HasOne("Immo.Domain.BusinessDomain.Search", "Search")
                        .WithMany("SeachLocations")
                        .HasForeignKey("SearchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Immo.Domain.BusinessDomain.Town", "Town")
                        .WithMany()
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Immo.Domain.BusinessDomain.Town", b =>
                {
                    b.HasOne("Immo.Domain.BusinessDomain.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}