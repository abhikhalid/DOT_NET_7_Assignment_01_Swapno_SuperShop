using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Data;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Invoice;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Services.InvoiceService
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public InvoiceService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetManagerId() => int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);


        public async Task<ServiceResponse<List<GetInvoiceDto>>> GetAllInvoices()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetInvoiceDto>> GetInvoiceById(int invoiceId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetInvoiceDto>>> SellProduct(AddSellProductDto sellProductDto)
        {
            var serviceResponse = new ServiceResponse<List<GetInvoiceDto>>();

            //customer is already exists
            bool flag = await CheckCustomerExists(sellProductDto);

            if (!flag)
            {
                throw new Exception("Customer with Id = " + sellProductDto.CustomerId + " not found!");
            }
            else
            {
                await CreateCustomer(sellProductDto);
            }

            //check if the shopId is valid or not
            var shop = await _context.Shops.FirstOrDefaultAsync(shop => shop.Id == sellProductDto.ShopId);

            if (shop is null)
            {
                throw new Exception("Shop with Id = " + sellProductDto.ShopId + " not found!");
            }

            var invoice = _mapper.Map<Invoice>(sellProductDto);

            _context.Invoices.Add(invoice);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Invoices
            .Where(invoice => invoice.Shop.ManagerId == GetManagerId())
            .Select(invoice => _mapper.Map<GetInvoiceDto>(invoice)).ToListAsync();

            return serviceResponse;
        }

        private async Task<bool> CheckCustomerExists(AddSellProductDto sellProductDto)
        {
            if (sellProductDto.CustomerId is not null)
            {
                //now, check if the customer id is valid or not
                var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == sellProductDto.CustomerId);

                if (customer is null)
                {
                    return false;
                }
            }
            return true;
        }

        private async Task CreateCustomer(AddSellProductDto sellProductDto)
        {
            //new cutomer. Create a new record for Customer Table
            var customer = _mapper.Map<Customer>(sellProductDto.addCustomerDto);
            _context.Customers.Add(customer);

            await _context.SaveChangesAsync();
        }
    }
}