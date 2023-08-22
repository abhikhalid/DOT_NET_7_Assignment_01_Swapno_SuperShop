using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Customer;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<ServiceResponse<List<GetCustomerDto>>> GetAllCustomers();

        Task<ServiceResponse<GetCustomerDto>> GetCustomerById(int customerId);

        Task<ServiceResponse<List<GetCustomerDto>>> AddCustomer(AddCustomerDto newCustomer);

        Task<ServiceResponse<GetCustomerDto>> UpdateCustomer(UpdateCustomerDto updatedCustomer);

        Task<ServiceResponse<List<GetCustomerDto>>> DeleteCustomer(int id);
    }
}