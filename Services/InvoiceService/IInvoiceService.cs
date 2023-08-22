using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Services.InvoiceService
{
    public interface IInvoiceService
    {
        Task<ServiceResponse<GetAllInvoices>> CreateInvoices(AddInvoiceDto addInvoiceDto);
    }
}