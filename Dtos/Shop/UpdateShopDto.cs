using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Shop
{
    public class UpdateShopDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "SHWAPNO";
        public string Address { get; set; } = string.Empty;

        public string PhoneNo { get; set; } = string.Empty;
        // public int ManagerId { get; set; }
    }
}