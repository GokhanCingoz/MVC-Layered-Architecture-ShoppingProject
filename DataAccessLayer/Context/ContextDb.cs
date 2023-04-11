using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Domain;

namespace DataAccessLayer.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } 
        public DbSet<Product> Products { get; set; } 
        public DbSet<User> Users { get; set; } 
        public DbSet<Delivery> Deliveries { get; set; } 
        public DbSet<Cart> Carts { get; set; } 
        public DbSet<Favorite> Favorites { get; set; } 
        public DbSet<DeliveryItem> DeliveryDetails { get; set; } 
    }
}
