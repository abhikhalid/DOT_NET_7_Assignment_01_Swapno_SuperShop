using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public DateTime date { get; set; }

        public Shop Shop { get; set; }

        public List<InvoiceInfo> InvoiceInfos { get; set; }
    }
}