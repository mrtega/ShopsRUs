using Microsoft.EntityFrameworkCore;
using ShopsRUs.Data;
using ShopsRUs.Helpers;
using ShopsRUs.Interfaces;
using ShopsRUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly Context _context;
        private readonly AppSettings _config;

        public DiscountService(Context context)
        {
            _context = context;
        }

        public async Task<Response<DiscountResponse>> Create(CreateDiscountRequest request)
        {
            if (string.IsNullOrEmpty(request.Type))
            {
                return new Response<DiscountResponse>(Constants.STATUS_FAIL, "No type provided", null);
            }

            Discount discount = new();

            try
            {
                discount.DateAdded = DateTime.Now;
                discount.Type = request.Type.ToUpper();
                discount.DiscountPercentage = request.DiscountPercentage;

                _context.Discounts.Add(discount);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            DiscountResponse discountResponse = new DiscountResponse()
            {
                Type = request.Type,
                DiscountPercentage = request.DiscountPercentage
            };

            return new Response<DiscountResponse>(Constants.STATUS_SUCCESS, "Discount Successfully Created", discountResponse);
        }

        public async Task<List<Discount>> GetAllDiscounts()
        {
            List<Discount> discounts = new();
            discounts = await _context.Discounts.OrderBy(x => x.Type).ToListAsync();
            return discounts;
        }

        public async Task<Response<Discount>> GetDiscountByType(string type)
        {
            Discount discount = new();
            discount = await _context.Discounts.FirstOrDefaultAsync(x => x.Type == type.ToUpper());
            if (type != null)
            {
                return new Response<Discount>(Constants.STATUS_SUCCESS, $"Discount exist with name {type.ToUpper()}", discount);
            }
            return new Response<Discount>(Constants.STATUS_FAIL, $"No discount found with name {type.ToUpper()}", null);
        }
    }
}
