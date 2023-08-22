using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Customer
{
    public class UpdateCustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string MobileNo { get; set; }
    }
}