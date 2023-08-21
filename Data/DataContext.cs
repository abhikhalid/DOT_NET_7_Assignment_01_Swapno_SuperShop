using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;
using Microsoft.EntityFrameworkCore;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Manager> Managers => Set<Manager>();

        public DbSet<Shop> Shops => Set<Shop>();
        // public DbSet<Customer> Customers => Set<Customer>();
        // public DbSet<Product> Products => Set<Product>();

    }
}