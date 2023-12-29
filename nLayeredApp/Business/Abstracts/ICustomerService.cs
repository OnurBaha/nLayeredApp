using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICustomerService
    {
        Task<IPaginate<GetListCustomerResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCustomerResponse> Add(CreateCustomerRequest createCustomerRequest);
        Task<DeletedCustomerResponse> Delete(DeleteCustomerRequest deleteCustomerRequest);
        Task<UpdatedCustomerResponse> Update(UpdateCustomerRequest updateCustomerRequest);
        Task<CreatedCustomerResponse> GetById(string id);
    }
}
