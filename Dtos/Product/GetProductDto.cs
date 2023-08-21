using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Product
{
    public class GetProductDto
    {
        public string ProductName { get; set; } = string.Empty;

        public float Price { get; set; }
    }
}