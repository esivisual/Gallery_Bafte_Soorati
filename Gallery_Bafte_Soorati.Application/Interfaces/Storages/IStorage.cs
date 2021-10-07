using Gallery_Bafte_Soorati.Domain.Entities.Carts;
using Gallery_Bafte_Soorati.Domain.Entities.Common;
using Gallery_Bafte_Soorati.Domain.Entities.Finance;
using Gallery_Bafte_Soorati.Domain.Entities.HomePages;
using Gallery_Bafte_Soorati.Domain.Entities.Orders;
using Gallery_Bafte_Soorati.Domain.Entities.Products;
using Gallery_Bafte_Soorati.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gallery_Bafte_Soorati.Application.Interfaces.Storages
{
     public interface IStorage 
     {
         DbSet<User> Users { get; set; }
         DbSet<Roles> Roles { get; set; }
         DbSet<UserInRole> UserInRoles { get; set; }
         DbSet<Product> Products { get; set; }
         DbSet<ProductComments> ProductComments { get; set; }
         DbSet<ProductFeatures> ProductFeatures { get; set; }
         DbSet<ProductImages > ProductImages { get; set; }
         DbSet<Cart> Carts { get; set; }
         DbSet<CartItem> CartItems { get; set; }
         DbSet<RequestPay> RequestPays { get; set; }
         DbSet<HomePageImage> HomePageImages { get; set; }
         DbSet<Slider> Sliders { get; set; }
         DbSet<Order> Orders { get; set; }
         DbSet<OrderDetail> OrderDetails { get; set; }
         DbSet<Category> Categories { get; set; }
        
        int SaveChanges(bool AcceptOnSuccesss);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken =new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
     }
}
