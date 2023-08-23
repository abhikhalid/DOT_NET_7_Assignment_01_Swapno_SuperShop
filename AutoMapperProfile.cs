using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Customer;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Manager;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Product;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Shop;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Shop, GetShopDto>();
            // CreateMap<Shop, GetShopDto>().ReverseMap();
            CreateMap<AddShopDto, Shop>().ReverseMap();
            CreateMap<UpdateShopDto, Shop>();
            CreateMap<Manager, GetManagerDto>();
            CreateMap<Product, GetProductDto>();
            CreateMap<Customer, GetCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<AddCustomerDto, Customer>().ReverseMap();
            
            CreateMap<AddCustomerDto, Customer>().ReverseMap();
        }
    }
}