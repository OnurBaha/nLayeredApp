using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Customer : Entity<string>
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string? Country { get; set; }
    }
}
