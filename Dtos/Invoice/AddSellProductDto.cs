using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Customer;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Invoice
{
    public class AddSellProductDto
    {
        public int? CustomerId { get; set; }

        public AddCustomerDto? addCustomerDto { get; set; }

        public int ShopId { get; set; }

        public List<CartDto> CartDtos { get; set; }
    }
}