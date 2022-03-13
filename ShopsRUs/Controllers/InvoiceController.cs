using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Helpers;
using ShopsRUs.Interfaces;
using ShopsRUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Controllers
{
    [ApiController]
    [Route("ShopsRUs/Invoice/[action]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<IActionResult> GetTotalInvoiceAmount(InvoiceRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var resp = await _invoiceService.GetTotalInvoiceAmount(request);
                    return Ok(resp);
                }

                return new BadRequestObjectResult(new Response<InvoiceResponse>(string.Empty, "Invalid Request", null));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new Response<InvoiceResponse>(Constants.STATUS_FAIL, "An unexpected error occurred.", null));
            }
        }
    }
}
