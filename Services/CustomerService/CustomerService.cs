using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Data;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Customer;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CustomerService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCustomerDto>>> AddCustomer(AddCustomerDto newCustomer)
        {
            var serviceResponse = new ServiceResponse<List<GetCustomerDto>>();

            var customer = _mapper.Map<Customer>(newCustomer);

            _context.Customers.Add(customer);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Customers.Select(customer => _mapper.Map<GetCustomerDto>(customer)).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCustomerDto>>> DeleteCustomer(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCustomerDto>>();

            var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);

            if (customer is null)
            {
                throw new Exception("Customer with Id = " + id + " not found!");
            }

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Customers.Select(customer => _mapper.Map<GetCustomerDto>(customer)).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCustomerDto>>> GetAllCustomers()
        {
            var serviceResponse = new ServiceResponse<List<GetCustomerDto>>();

            var dbCustomers = await _context.Customers.ToListAsync();

            serviceResponse.Data = dbCustomers.Select(customer => _mapper.Map<GetCustomerDto>(customer)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCustomerDto>> GetCustomerById(int customerId)
        {
            var serviceResponse = new ServiceResponse<GetCustomerDto>();

            var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == customerId);

            if (customer is null)
            {
                throw new Exception("Customer with Id = " + customerId + " Not found!");
            }

            serviceResponse.Data = _mapper.Map<GetCustomerDto>(customer);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCustomerDto>> UpdateCustomer(UpdateCustomerDto updatedCustomer)
        {
            var serviceResponse = new ServiceResponse<GetCustomerDto>();

            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == updatedCustomer.Id);

                if (customer == null)
                {
                    throw new Exception("Customer with Id = " + updatedCustomer.Id + " not found!");
                }

                _mapper.Map(updatedCustomer, customer);

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCustomerDto>(customer);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}