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
    [Route("ShopsRUs/Customer/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var resp = await _customerService.GetAllCustomers();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new Response<CustomerResponse>(Constants.STATUS_FAIL, "An unexpected error occurred.", null));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var resp = await _customerService.Create(request);
                    return Ok(resp);
                }

                return new BadRequestObjectResult(new Response<CustomerResponse>(string.Empty, "Invalid Request", null));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new Response<CustomerResponse>(Constants.STATUS_FAIL, "An unexpected error occurred.", null));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerById(long id)
        {
            try
            {
                var resp = await _customerService.GetCustomerById(id);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new Response<CustomerResponse>(Constants.STATUS_FAIL, "An unexpected error occurred.", null));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerByName(string name)
        {
            try
            {
                var resp = await _customerService.GetCustomerByName(name);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new Response<CustomerResponse>(Constants.STATUS_FAIL, "An unexpected error occurred.", null));
            }
        }
    }
}
