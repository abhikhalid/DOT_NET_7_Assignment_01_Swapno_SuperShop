using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Shop;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Services.ShopService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetShopDto>>>> GetAllShops()
        {
            return Ok(await _shopService.GetAllShops());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetShopDto>>>> AddShop(AddShopDto newShop)
        {
            return Ok(await _shopService.AddShop(newShop));
        }

        [HttpPost("Product")]
        public async Task<ActionResult<ServiceResponse<GetShopDto>>> AddShopProduct(AddShopProductDto newShopProduct)
        {
            return Ok(await _shopService.AddShopProduct(newShopProduct));
        }

        [HttpGet("{shopId}")]
        public async Task<ActionResult<ServiceResponse<GetShopDto>>> GetShopById(int shopId)
        {
            return Ok(await _shopService.GetShopById(shopId));
        }
    }
}