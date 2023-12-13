using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}