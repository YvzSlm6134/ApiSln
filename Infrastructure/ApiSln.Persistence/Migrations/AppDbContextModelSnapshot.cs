﻿// <auto-generated />
using System;
using ApiSln.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiSln.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiSln.Domain.Entitys.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("İsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 8, 1, 13, 57, 27, 345, DateTimeKind.Local).AddTicks(5528),
                            Name = "Movies & Kids",
                            İsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 8, 1, 13, 57, 27, 345, DateTimeKind.Local).AddTicks(5538),
                            Name = "Computers & Baby",
                            İsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 8, 1, 13, 57, 27, 345, DateTimeKind.Local).AddTicks(5550),
                            Name = "Health, Jewelery & Jewelery",
                            İsDeleted = true
                        });
                });

            modelBuilder.Entity("ApiSln.Domain.Entitys.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Priorty")
                        .HasColumnType("int");

                    b.Property<bool>("İsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 8, 1, 13, 57, 27, 345, DateTimeKind.Local).AddTicks(6582),
                            Name = "Elektrik",
                            ParentId = 0,
                            Priorty = 1,
                            İsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 8, 1, 13, 57, 27, 345, DateTimeKind.Local).AddTicks(6584),
                            Name = "Moda",
                            ParentId = 0,
                            Priorty = 2,
                            İsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 8, 1, 13, 57, 27, 345, DateTimeKind.Local).AddTicks(6585),
                            Name = "Bilgisayar",
                            ParentId = 1,
                            Priorty = 1,
                            İsDeleted = false
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 8, 1, 13, 57, 27, 345, DateTimeKind.Local).AddTicks(6586),
                            Name = "Kadın",
                            ParentId = 1,
                            Priorty = 1,
                            İsDeleted = false
                        });
                });

            modelBuilder.Entity("ApiSln.Domain.Entitys.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("İsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 8, 1, 13, 57, 27, 346, DateTimeKind.Local).AddTicks(6690),
                            Description = "Eos hesap ut değerli autem.",
                            Title = "Aut.",
                            İsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2024, 8, 1, 13, 57, 27, 346, DateTimeKind.Local).AddTicks(6729),
                            Description = "İçin voluptatem dolorem gülüyorum blanditiis.",
                            Title = "Qui türemiş.",
                            İsDeleted = true
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 4,
                            CreatedDate = new DateTime(2024, 8, 1, 13, 57, 27, 346, DateTimeKind.Local).AddTicks(6750),
                            Description = "Suscipit lakin düşünüyor autem totam.",
                            Title = "Masaya.",
                            İsDeleted = false
                        });
                });

            modelBuilder.Entity("ApiSln.Domain.Entitys.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("İsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreatedDate = new DateTime(2024, 8, 1, 13, 57, 27, 348, DateTimeKind.Local).AddTicks(1129),
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            Discount = 2.844202204430880m,
                            Price = 505.59m,
                            Title = "Rustic Soft Hat",
                            İsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 3,
                            CreatedDate = new DateTime(2024, 8, 1, 13, 57, 27, 348, DateTimeKind.Local).AddTicks(1147),
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            Discount = 0.8219937809359840m,
                            Price = 308.60m,
                            Title = "Ergonomic Metal Towels",
                            İsDeleted = false
                        });
                });

            modelBuilder.Entity("ApiSln.Domain.Entitys.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("ApiSln.Domain.Entitys.Detail", b =>
                {
                    b.HasOne("ApiSln.Domain.Entitys.Category", "Category")
                        .WithMany("Details")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ApiSln.Domain.Entitys.Product", b =>
                {
                    b.HasOne("ApiSln.Domain.Entitys.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("ApiSln.Domain.Entitys.ProductCategory", b =>
                {
                    b.HasOne("ApiSln.Domain.Entitys.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiSln.Domain.Entitys.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ApiSln.Domain.Entitys.Category", b =>
                {
                    b.Navigation("Details");

                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("ApiSln.Domain.Entitys.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
