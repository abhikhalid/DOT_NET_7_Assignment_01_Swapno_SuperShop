using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // Data Seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, ProductName = "IPhone", Price = 302324 },
                new Product { Id = 2, ProductName = "Macbook", Price = 23450 },
                new Product { Id = 3, ProductName = "Laptop", Price = 22340 }
            );
        }

        public DbSet<Manager> Managers => Set<Manager>();

        public DbSet<Shop> Shops => Set<Shop>();
        // public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Product> Products => Set<Product>();

    }
}