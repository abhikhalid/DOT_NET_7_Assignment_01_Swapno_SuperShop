using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Models
{
    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Swapno";

        public string Address { get; set; } = string.Empty;

        public string PhoneNo { get; set; } = string.Empty;

        public Manager? Manager { get; set; }

        public int ManagerId { get; set; }

        public List<Product>? Products { get; set; }
    }
}