using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests
{
    public class UpdateCustomerRequest
    {
        public string Id { get; set; }
        public string CompanyName { get; set; }
    }
}
