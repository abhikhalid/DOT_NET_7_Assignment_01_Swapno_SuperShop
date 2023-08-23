using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Models
{
  public class Product
  {
    public int Id { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public float Price { get; set; }


    public int Quantity { get; set; }

    public List<Shop> Shops { get; set; }

    public List<InvoiceInfo> InvoiceInfos { get; set; }
  }
}