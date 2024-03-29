﻿using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Web.Buyify.Models;

namespace Web.Buyify
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=185.166.188.154;Database=u948053727_buyify;User=u948053727_buyify;Password=Decembre@20144;");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CartItem>().HasKey(c => c.ProductId);
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<UserCustomer> UsersCustomers { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryMag> CategoryMag { get; set; }
        public DbSet<Magasin> Magasin { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
