using ShopsRUs.Data;
using ShopsRUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Interfaces
{
    public interface IDiscountService
    {
        Task<List<Discount>> GetAllDiscounts();

        Task<Response<DiscountResponse>> Create(CreateDiscountRequest request);

        Task<Response<Discount>> GetDiscountByType(string type);

    }
}
