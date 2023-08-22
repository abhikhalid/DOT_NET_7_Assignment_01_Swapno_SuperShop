using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Customer;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Services.CustomerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCustomerDto>>>> AddCustomer(AddCustomerDto newCustomer)
        {
            var response = await _customerService.AddCustomer(newCustomer);

            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult<ServiceResponse<List<GetCustomerDto>>>> DeleteCustomer(int customerId)
        {
            var response = await _customerService.DeleteCustomer(customerId);

            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCustomerDto>>>> GetAllCustomers()
        {
            return Ok(await _customerService.GetAllCustomers());
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<ServiceResponse<GetCustomerDto>>> GetCustomerById(int customerId)
        {
            var response = await _customerService.GetCustomerById(customerId);

            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCustomerDto>>> UpdateCustomer(UpdateCustomerDto updatedCustomer)
        {
            var response = await _customerService.UpdateCustomer(updatedCustomer);

            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}