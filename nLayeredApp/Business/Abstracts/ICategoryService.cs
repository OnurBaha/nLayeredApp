using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Core.Persistence.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICategoryService
    {
        Task<IPaginate<GetListCategoryResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest);
    }
}