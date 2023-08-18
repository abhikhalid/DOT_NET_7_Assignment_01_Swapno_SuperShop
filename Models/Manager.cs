using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Models
{
    public class Manager
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];

    }
}