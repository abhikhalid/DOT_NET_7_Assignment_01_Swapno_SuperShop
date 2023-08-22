using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Customer;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        public Task<ServiceResponse<List<GetCustomerDto>>> AddCustomer(AddCustomerDto newCustomer)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetCustomerDto>>> DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetCustomerDto>>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetCustomerDto>> GetCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetCustomerDto>> UpdateCustomer(UpdateCustomerDto updatedCustomer)
        {
            throw new NotImplementedException();
        }
    }
}