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
    public class InvoiceService : IInvoiceService
    {
        private readonly Context _context;
        private readonly AppSettings _config;

        public InvoiceService(Context context)
        {
            _context = context;
        }
        public async Task<Response<InvoiceResponse>> GetTotalInvoiceAmount(InvoiceRequest request)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.CustomerId);
            var discount = await _context.Discounts.FirstOrDefaultAsync(x => x.Type == request.ItemsPurchased);
            decimal discountedPrice = request.Price;
            bool discountApplied = false;
            string typeofDiscount = null;

            if (customer == null)
            {
                return new Response<InvoiceResponse>(Constants.STATUS_FAIL, "Customer not found", null);
            }
            if (request.Price <= 0)
            {
                return new Response<InvoiceResponse>(Constants.STATUS_FAIL, "Invalid amount", null);
            }

            if (!string.Equals(request.ItemsPurchased, Constants.GROCERIES, StringComparison.OrdinalIgnoreCase))
            {
                if (customer.Employee)
                {
                    decimal discountPercent = Decimal.Divide(30,100);
                    discountedPrice = request.Price - (request.Price * discountPercent);
                    discountApplied = true;
                    typeofDiscount = "Employee discount of 30%.";
                }
                else if (customer.Affiliate)
                {
                    decimal discountPercent = Decimal.Divide(10, 100);
                    discountedPrice = request.Price - (request.Price * discountPercent);
                    discountApplied = true;
                    typeofDiscount = "Affiliate discount of 10%.";
                }
                else if (customer.DateRegistered.Date < DateTime.Now.AddYears(-2).Date)
                {
                    decimal discountPercent = Decimal.Divide(5, 100);
                    discountedPrice = request.Price - (request.Price * discountPercent);
                    discountApplied = true;
                    typeofDiscount = "Discount of 5% applied, customer for over 2 years.";
                }
                else if (discount != null)
                {
                    decimal discountPercent = Decimal.Divide(discount.DiscountPercentage, 100);
                    discountedPrice = request.Price - (request.Price * discountPercent);
                    discountApplied = true;
                    typeofDiscount = $"Discount of {discount.DiscountPercentage}% applied, discount on items purchased.";
                }
            }
            if (request.Price / 100 > 1 && discountedPrice == request.Price)
            {
                decimal noOfHundredBill = request.Price / 100;
                discountedPrice = request.Price - (5 * noOfHundredBill);
                discountApplied = true;
                typeofDiscount = "Discount of 5% on every 100$ bill applied.";
            }


            try
            {
                Invoice invoice = new Invoice
                {
                    CustomerId = request.CustomerId,
                    Price = request.Price,
                    DiscountedPrice = discountedPrice,
                    ItemsPurchased = request.ItemsPurchased,
                    DateCreated = DateTime.Now,
                    DiscountApplied = discountApplied,
                    TypeOfDiscount = typeofDiscount
                };
                await _context.Invoices.AddAsync(invoice);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            InvoiceResponse invoiceResponse = new InvoiceResponse
            {
                CustomerId = request.CustomerId,
                Price = request.Price,
                DiscountedPrice = discountedPrice,
                ItemsPurchased = request.ItemsPurchased,
                DateCreated = DateTime.Now,
                DiscountApplied = discountApplied,
                TypeOfDiscount = typeofDiscount
                
            };

            return new Response<InvoiceResponse>(Constants.STATUS_SUCCESS, "Invoice successfully created", invoiceResponse);
        }
    }
}
