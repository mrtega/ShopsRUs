using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Data
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long CustomerId { get; set; }

        public Customer Customer { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountedPrice { get; set; }

        public string ItemsPurchased { get; set; }

        public DateTime DateCreated { get; set; }

        public bool DiscountApplied { get; set; }

        public string TypeOfDiscount { get; set; }
    }
}
