using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(Manager manger, string password);

        Task<ServiceResponse<string>> Login(string username,string password);

        Task<bool> UserExists(string username);
    }
}