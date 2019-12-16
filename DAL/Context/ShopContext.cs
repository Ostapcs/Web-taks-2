using System;
using System.Collections.Generic;
using System.Text;
using DAL.Configs;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ShopContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrders> ProductOrders { get; set; }
        public DbSet<CartProducts> CartProducts { get; set; }

        public ShopContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modalBuilder)
        {
            modalBuilder.ApplyConfiguration(new UserConfig());
            modalBuilder.ApplyConfiguration(new CommentConfig());
            modalBuilder.ApplyConfiguration(new OrderConfig());
            modalBuilder.ApplyConfiguration(new ProductConfig());
            modalBuilder.ApplyConfiguration(new ProductOrdersConfig());
            modalBuilder.ApplyConfiguration(new CartProductsConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=shop-db;Trusted_Connection=True;");
            optionsBuilder
                .UseNpgsql("Host=localhost;Port=5432;Database=shop-db;Username=postgres;Password=password");
        }
    }
}
