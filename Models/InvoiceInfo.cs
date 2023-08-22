using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Models
{
    public class InvoiceInfo
    {
        public int Id { get; set; }

        public Invoice Invoice { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}