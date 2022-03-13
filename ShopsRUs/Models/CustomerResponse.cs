using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Models
{
    public class CustomerResponse
    {
        public long CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
