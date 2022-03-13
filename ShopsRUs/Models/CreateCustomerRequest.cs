using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Models
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; }

        public bool Affiliate { get; set; }

        public bool Employee { get; set; }

        public DateTime DateRegistered { get; set; }
    }
}
