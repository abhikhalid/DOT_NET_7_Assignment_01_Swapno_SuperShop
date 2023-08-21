using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Shop;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Services.ShopService
{
    public interface IShopService
    {
        Task<ServiceResponse<List<GetShopDto>>> GetAllShops();

        Task<ServiceResponse<List<GetShopDto>>> AddShop(AddShopDto newShop);

        Task<ServiceResponse<List<GetShopDto>>> DeleteShop(int shopId);

        Task<ServiceResponse<GetShopDto>> GetShopById(int shopId);

        Task<ServiceResponse<GetShopDto>> UpdateShop(UpdateShopDto updateShop);

        Task<ServiceResponse<GetShopDto>> AddShopProduct(AddShopProductDto newShopProduct);
    }
}