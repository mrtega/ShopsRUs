using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Models
{
    public class InvoiceResponse
    {
        public long CustomerId { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountedPrice { get; set; }

        public string ItemsPurchased { get; set; }

        public DateTime DateCreated { get; set; }

        public bool DiscountApplied { get; set; }

        public string TypeOfDiscount { get; set; }
    }
}
