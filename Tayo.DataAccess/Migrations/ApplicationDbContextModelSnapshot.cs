﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tayo.DataAccess.Data;

#nullable disable

namespace Tayo.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tayo.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Shoes"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Jeans"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Shirts"
                        });
                });

            modelBuilder.Entity("Tayo.Models.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Collections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 8,
                            Name = "Mens"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 21,
                            Name = "Womens"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 9,
                            Name = "Kids"
                        });
                });

            modelBuilder.Entity("Tayo.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("ProductColorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ProductSizeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CollectionId");

                    b.HasIndex("ProductColorId");

                    b.HasIndex("ProductSizeId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CollectionId = 1,
                            Description = "A comfortable white t-shirt made from 100% cotton.",
                            DisplayOrder = 1,
                            ImageUrl = "",
                            IsAvailable = true,
                            Name = "Classic White T-Shirt",
                            Price = 19.99m,
                            ProductColorId = 1,
                            ProductSizeId = 2
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CollectionId = 2,
                            Description = "A stylish blue denim jacket perfect for casual wear.",
                            DisplayOrder = 2,
                            ImageUrl = "",
                            IsAvailable = true,
                            Name = "Blue Denim Jacket",
                            Price = 49.99m,
                            ProductColorId = 2,
                            ProductSizeId = 3
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CollectionId = 3,
                            Description = "Durable black leather boots for all-weather conditions.",
                            DisplayOrder = 3,
                            ImageUrl = "",
                            IsAvailable = true,
                            Name = "Black Leather Boots",
                            Price = 89.99m,
                            ProductColorId = 1,
                            ProductSizeId = 4
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            CollectionId = 1,
                            Description = "A lightweight red cotton dress, perfect for summer outings.",
                            DisplayOrder = 4,
                            ImageUrl = "",
                            IsAvailable = true,
                            Name = "Red Cotton Dress",
                            Price = 39.99m,
                            ProductColorId = 2,
                            ProductSizeId = 2
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            CollectionId = 2,
                            Description = "A high-quality brown leather belt with a silver buckle.",
                            DisplayOrder = 5,
                            ImageUrl = "",
                            IsAvailable = true,
                            Name = "Brown Leather Belt",
                            Price = 24.99m,
                            ProductColorId = 1,
                            ProductSizeId = 1
                        });
                });

            modelBuilder.Entity("Tayo.Models.ProductColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ProductColors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            IsActive = true,
                            Name = "Black"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            IsActive = true,
                            Name = "White"
                        });
                });

            modelBuilder.Entity("Tayo.Models.ProductSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ProductSizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            IsActive = true,
                            Name = "Small"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            IsActive = true,
                            Name = "Medium"
                        });
                });

            modelBuilder.Entity("Tayo.Models.Product", b =>
                {
                    b.HasOne("Tayo.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tayo.Models.Collection", "Collection")
                        .WithMany()
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tayo.Models.ProductColor", "ProductColor")
                        .WithMany()
                        .HasForeignKey("ProductColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tayo.Models.ProductSize", "ProductSize")
                        .WithMany()
                        .HasForeignKey("ProductSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Collection");

                    b.Navigation("ProductColor");

                    b.Navigation("ProductSize");
                });
#pragma warning restore 612, 618
        }
    }
}
