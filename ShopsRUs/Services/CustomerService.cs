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
    public class CustomerService : ICustomerService
    {
        private readonly Context _context;
        private readonly AppSettings _config;
        
        public CustomerService(Context context)
        {
            _context = context;
        }

        public async Task<Response<CustomerResponse>> Create(CreateCustomerRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                return new Response<CustomerResponse>(Constants.STATUS_FAIL, "No name provided", null);
            }

            Customer customer = new();
            
            try
            {
                customer.DateRegistered = request.DateRegistered;
                customer.DateAdded = DateTime.Now;
                customer.Name = request.Name.ToUpper();
                customer.Affiliate = request.Affiliate;
                customer.Employee = request.Employee;

                _context.Customers.Add(customer);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            CustomerResponse customerResponse = new CustomerResponse()
            {
                CustomerId = customer.Id,
                Name = customer.Name,
                DateCreated = customer.DateAdded
            };

            return new Response<CustomerResponse>(Constants.STATUS_SUCCESS, "Customer successfully created", customerResponse);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> customers = new();
            customers = await _context.Customers.OrderBy(x => x.Name).ToListAsync();
            return customers;
        }

        public async Task<Response<Customer>> GetCustomerById(long Id)
        {
            Customer customer = new();
            customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == Id);
            if (customer != null)
            {
                return new Response<Customer>(Constants.STATUS_SUCCESS, $"Customer Exist with ID : {Id}", customer);
            }
            return new Response<Customer>(Constants.STATUS_FAIL, $"No customer found with ID {Id}", null);
        }

        public async Task<Response<Customer>> GetCustomerByName(string name)
        {
            Customer customer = new();
            customer = await _context.Customers.FirstOrDefaultAsync(x => x.Name == name.ToUpper());
            if (customer != null)
            {
                return new Response<Customer>(Constants.STATUS_SUCCESS, $"Customer Exist with name {name.ToUpper()}", customer);
            }
            return new Response<Customer>(Constants.STATUS_FAIL, $"No customer found with name {name.ToUpper()}", null);
        }

    }
}
