using BurgerAppRefactored.Domain;
using Microsoft.EntityFrameworkCore;

namespace BurgerAppRefactored.DataAccess
{
    public class BurgerAppRefactoredDbContext : DbContext
    {
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BurgerOrderItem> BurgerOrderItems { get; set; }
        public DbSet<ExtraOrderItem> ExtraOrderItems { get; set; }
        public BurgerAppRefactoredDbContext(DbContextOptions<BurgerAppRefactoredDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Burger>(x => x.ToTable("Burger"));
            builder.Entity<Extra>(x => x.ToTable("Extra"));
            builder.Entity<Order>(x => x.ToTable("Order"));
            builder.Entity<BurgerOrderItem>(x => x.ToTable("BurgerOrderItem"));
            builder.Entity<ExtraOrderItem>(x => x.ToTable("ExtraOrderItem"));

            builder.Entity<Burger>().HasData
            (
                new Burger("Regular burger", "Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6", "https://www.hardees.com/-/media/project/cke/hardees/double-cheeseburger-705-x-401.jpgs", false, false, 200) { Id = 1 },
                new Burger("Hamburger", "Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6", "https://www.hardees.com/-/media/project/cke/hardees/double-cheeseburger-705-x-401.jpgs", false, false, 250) { Id = 2 },
                new Burger("Cheese Burger", "Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6", "https://www.hardees.com/-/media/project/cke/hardees/double-cheeseburger-705-x-401.jpgs", false, false, 300) { Id = 3 }
            );

            builder.Entity<Extra>().HasData
            (
                new Extra("Fries", 50) { Id = 1 },
                new Extra("Extra2", 100) { Id = 2 },
                new Extra("Extra3", 150) { Id = 3 }
            );
        }
    }
}
