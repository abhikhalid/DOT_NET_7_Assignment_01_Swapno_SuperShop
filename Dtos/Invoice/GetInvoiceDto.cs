using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Customer;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Product;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Shop;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Invoice
{
    public class GetInvoiceDto
    {
        public GetCustomerDto CustomerDto { get; set; }

        public DateTime Date { get; set; }

        public GetShopDto GetShopDto { get; set; }

        public List<GetProductDto> GetProductDtos { get; set; }
    }
}