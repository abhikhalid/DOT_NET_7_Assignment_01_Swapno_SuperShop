using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Data;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Shop;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Services.ShopService
{
    public class ShopService : IShopService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShopService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetManagerId() => int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);


        public async Task<ServiceResponse<List<GetShopDto>>> GetAllShops()
        {
            var serviceResponse = new ServiceResponse<List<GetShopDto>>();

            var dbShops = await _context.Shops
                                .Include(s => s.Manager)
                                //.Include(s => s.Products)
                                .Where(s => s.Manager!.Id == GetManagerId())
                                .ToListAsync();

            serviceResponse.Data = dbShops.Select(s => _mapper.Map<GetShopDto>(s)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetShopDto>>> AddShop(AddShopDto newShop)
        {
            var serviceResponse = new ServiceResponse<List<GetShopDto>>();

            var shop = _mapper.Map<Shop>(newShop);

            shop.Manager = await _context.Managers.FirstOrDefaultAsync(u => u.Id == GetManagerId());

            _context.Shops.Add(shop);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Shops.Where(s => s.Manager!.Id == GetManagerId())
                                   .Select(s => _mapper.Map<GetShopDto>(s)).ToListAsync();


            return serviceResponse;
        }

        public Task<ServiceResponse<List<GetShopDto>>> DeleteShop(int shopId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetShopDto>> GetShopById(int shopId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetShopDto>> UpdateShop(UpdateShopDto updateShop)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetShopDto>> AddShopProduct(AddShopProductDto newShopProduct)
        {
            throw new NotImplementedException();
        }
    }
}