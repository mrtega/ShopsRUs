using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Models
{
    public class CreateDiscountRequest
    {
        public string Type { get; set; }

        public int DiscountPercentage { get; set; }
    }
}
