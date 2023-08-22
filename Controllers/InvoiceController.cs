using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Dtos.Invoice;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Services.InvoiceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }


        [HttpDelete("{invoiceId}")]
        public async Task<ActionResult<ServiceResponse<List<GetInvoiceDto>>>> DeleteInvoice(int invoiceId)
        {

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetInvoiceDto>>>> GetAllInvoices()
        {

        }

        [HttpGet("{invoiceId}")]
        public async Task<ActionResult<ServiceResponse<GetInvoiceDto>>> GetInvoiceById(int invoiceId)
        {

        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetInvoiceDto>>>> SellProduct(AddSellProductDto sellProductDto)
        {

        }
    }
}