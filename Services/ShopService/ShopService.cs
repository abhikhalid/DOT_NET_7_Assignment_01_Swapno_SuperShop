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
                                .Include(s => s.Products)
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

        public async Task<ServiceResponse<List<GetShopDto>>> DeleteShop(int shopId)
        {
            var serviceResponse = new ServiceResponse<List<GetShopDto>>();

            try
            {
                var shop = await _context.Shops.FirstOrDefaultAsync(shop => shop.Id == shopId
                          && shop.Manager!.Id == GetManagerId());

                if (shop is null)
                {
                    throw new Exception("Shop with Id " + shopId + " not found!");
                }

                _context.Shops.Remove(shop);

                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Shops
                    .Where(s => s.Manager!.Id == GetManagerId())
                    .Select(s => _mapper.Map<GetShopDto>(s)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetShopDto>> GetShopById(int shopId)
        {
            var serviceResponse = new ServiceResponse<GetShopDto>();

            var dbShop = await _context.Shops
                         .Include(shop => shop.Manager)
                         .Include(shop => shop.Products)
                         .FirstOrDefaultAsync(shop => shop.Id == shopId && shop.Manager!.Id == GetManagerId());

            serviceResponse.Data = _mapper.Map<GetShopDto>(dbShop);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetShopDto>> UpdateShop(UpdateShopDto updateShop)
        {
            var serviceResponse = new ServiceResponse<GetShopDto>();

            try
            {
                var shop = await _context.Shops.Include(shop => shop.Manager).Include(shop => shop.Products)
                           .FirstOrDefaultAsync(shop => shop.Id == updateShop.Id);

                if (shop == null || shop.Manager!.Id != GetManagerId())
                {
                    throw new Exception("Shop with Id " + updateShop.Id + " not found!");
                }

                _mapper.Map(updateShop,shop);

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetShopDto>(shop);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        // many to many relationship
        public async Task<ServiceResponse<GetShopDto>> AddShopProduct(AddShopProductDto newShopProduct)
        {
            var response = new ServiceResponse<GetShopDto>();

            try
            {
                var shop = await _context.Shops
                                 .Include(shop => shop.Manager)
                                 .Include(shop => shop.Products)
                                 .FirstOrDefaultAsync(shop => shop.Id == newShopProduct.ShopId && shop.Manager!.Id == GetManagerId());

                if (shop is null)
                {
                    response.Success = false;
                    response.Message = "Shop not found!";
                    return response;
                }

                var product = await _context.Products
                                    .FirstOrDefaultAsync(product => product.Id == newShopProduct.ProductId);

                if (product is null)
                {
                    response.Success = false;
                    response.Message = "Product not found!";
                    return response;
                }

                shop.Products!.Add(product);

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetShopDto>(shop);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}