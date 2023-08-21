using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Shop
{
    public class AddShopDto
    {
        public string ShopName { get; set; } = "SHWAPNO";
        public string Address { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;
    }
}