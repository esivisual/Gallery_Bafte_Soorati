using Gallery_Bafte_Soorati.Application.Interfaces.Storages;
using Gallery_Bafte_Soorati.Domain.Entities.Carts;
using Gallery_Bafte_Soorati.Domain.Entities.Common;
using Gallery_Bafte_Soorati.Domain.Entities.Finance;
using Gallery_Bafte_Soorati.Domain.Entities.HomePages;
using Gallery_Bafte_Soorati.Domain.Entities.Orders;
using Gallery_Bafte_Soorati.Domain.Entities.Products;
using Gallery_Bafte_Soorati.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery_Bafte_Soorati.Presistance.DataBaseContext
{
    public class Storage : DbContext  , IStorage 
    {
        public Storage(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductComments>  ProductComments  { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<RequestPay>  RequestPays { get; set; }
        public DbSet<HomePageImage>  HomePageImages { get; set; }
        public DbSet<Slider>  Sliders { get; set; }
        public DbSet<Order>  Orders { get; set; }
        public DbSet<OrderDetail>  OrderDetails { get; set; }
        public DbSet<Category>  Categories { get; set; }

                                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(p => p.RequestPay).WithMany(p => p.Orders).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>().HasOne(p => p.User).WithMany(p => p.Orders).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasIndex(p => p.Email).IsUnique();

            SeedData(modelBuilder);
            ApplyTables(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private  static void ApplyTables(ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<User>().HasQueryFilter(P => ! P.IsRemoved);
            modelBuilder.Entity<Roles>().HasQueryFilter(P => !P.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(P => !P.IsRemoved);
            modelBuilder.Entity<Product>().HasQueryFilter(P => !P.IsRemoved);
            modelBuilder.Entity<ProductComments>().HasQueryFilter(P => !P.IsRemoved);
            modelBuilder.Entity<ProductFeatures>().HasQueryFilter(P => !P.IsRemoved);
            modelBuilder.Entity<ProductImages>().HasQueryFilter(P => !P.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(P => !P.IsRemoved);
            modelBuilder.Entity<Cart>().HasQueryFilter(P => !P.IsRemoved);
            modelBuilder.Entity<CartItem>().HasQueryFilter(P => !P.IsRemoved);
            modelBuilder.Entity<RequestPay>().HasQueryFilter(P => !P.IsRemoved);
            modelBuilder.Entity<HomePageImage>().HasQueryFilter(P => !P.IsRemoved);
            modelBuilder.Entity<Slider>().HasQueryFilter(P => !P.IsRemoved);
            modelBuilder.Entity<Order>().HasQueryFilter(P => !P.IsRemoved);
            modelBuilder.Entity<OrderDetail>().HasQueryFilter(P => !P.IsRemoved);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 1, Name = "Admin"    });
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 2, Name = "Operator" });
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 3, Name = "Customer" });
        }
    }
}

