using ShopsRUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Interfaces
{
    public interface IInvoiceService
    {
        Task<Response<InvoiceResponse>> GetTotalInvoiceAmount(InvoiceRequest request);
    }
}
