using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Invoice
{
    public class GetInvoiceDto
    {
        public Customer Customer { get; set; }

        public DateTime date { get; set; }

        public Shop Shop { get; set; }

        public List<InvoiceInfo>? InvoiceInfos { get; set; }
    }
}