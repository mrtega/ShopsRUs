using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Models
{
    public class InvoiceRequest
    {
        public long CustomerId { get; set; }

        public decimal Price { get; set; }

        public string ItemsPurchased { get; set; }

    }
}
