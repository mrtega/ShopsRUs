using ShopsRUs.Data;
using ShopsRUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();

        Task<Response<CustomerResponse>> Create(CreateCustomerRequest request);

        Task<Response<Customer>> GetCustomerById(long Id);

        Task<Response<Customer>> GetCustomerByName(string name);
    }
}
