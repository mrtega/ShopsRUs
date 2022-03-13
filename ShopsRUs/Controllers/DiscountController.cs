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
    [Route("ShopsRUs/Discount/[action]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscountRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var resp = await _discountService.Create(request);
                    return Ok(resp);
                }

                return new BadRequestObjectResult(new Response<DiscountResponse>(string.Empty, "Invalid Request", null));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new Response<DiscountResponse>(Constants.STATUS_FAIL, "An unexpected error occurred.", null));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscounts()
        {
            try
            {
                var resp = await _discountService.GetAllDiscounts();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new Response<DiscountResponse>(Constants.STATUS_FAIL, "An unexpected error occurred.", null));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscountByType(string type)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var resp = await _discountService.GetDiscountByType(type);
                    return Ok(resp);
                }

                return new BadRequestObjectResult(new Response<DiscountResponse>(string.Empty, "Invalid Request", null));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new Response<DiscountResponse>(Constants.STATUS_FAIL, "An unexpected error occurred.", null));
            }
        }
    }
}
