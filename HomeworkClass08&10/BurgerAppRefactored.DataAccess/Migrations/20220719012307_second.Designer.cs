﻿// <auto-generated />
using BurgerAppRefactored.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BurgerAppRefactored.DataAccess.Migrations
{
    [DbContext(typeof(BurgerAppRefactoredDbContext))]
    [Migration("20220719012307_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BurgerAppRefactored.Domain.Burger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVegan")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVegetarian")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Burger", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://www.hardees.com/-/media/project/cke/hardees/double-cheeseburger-705-x-401.jpgs",
                            Ingredients = "Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6",
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Regular burger",
                            Price = 200m
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "https://www.hardees.com/-/media/project/cke/hardees/double-cheeseburger-705-x-401.jpgs",
                            Ingredients = "Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6",
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Hamburger",
                            Price = 250m
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "https://www.hardees.com/-/media/project/cke/hardees/double-cheeseburger-705-x-401.jpgs",
                            Ingredients = "Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6",
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Cheese Burger",
                            Price = 300m
                        });
                });

            modelBuilder.Entity("BurgerAppRefactored.Domain.BurgerOrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BurgerId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BurgerId");

                    b.HasIndex("OrderId");

                    b.ToTable("BurgerOrderItem", (string)null);
                });

            modelBuilder.Entity("BurgerAppRefactored.Domain.Extra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Extra", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fries",
                            Price = 50m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Extra2",
                            Price = 100m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Extra3",
                            Price = 150m
                        });
                });

            modelBuilder.Entity("BurgerAppRefactored.Domain.ExtraOrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExtraId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExtraId");

                    b.HasIndex("OrderId");

                    b.ToTable("ExtraOrderItem", (string)null);
                });

            modelBuilder.Entity("BurgerAppRefactored.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOrderCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("BurgerAppRefactored.Domain.BurgerOrderItem", b =>
                {
                    b.HasOne("BurgerAppRefactored.Domain.Burger", "Burger")
                        .WithMany()
                        .HasForeignKey("BurgerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BurgerAppRefactored.Domain.Order", "Order")
                        .WithMany("Burgers")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Burger");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BurgerAppRefactored.Domain.ExtraOrderItem", b =>
                {
                    b.HasOne("BurgerAppRefactored.Domain.Extra", "Extra")
                        .WithMany()
                        .HasForeignKey("ExtraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BurgerAppRefactored.Domain.Order", "Order")
                        .WithMany("Extras")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Extra");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BurgerAppRefactored.Domain.Order", b =>
                {
                    b.Navigation("Burgers");

                    b.Navigation("Extras");
                });
#pragma warning restore 612, 618
        }
    }
}
