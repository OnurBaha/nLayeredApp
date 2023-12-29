using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.Persistence.Paging;

namespace Business.Abstracts
{
    public interface IProductService
    {
        Task<IPaginate<GetListProductResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest);
        Task<DeletedProductResponse> Delete(DeleteProductRequest deleteProductRequest);
        Task<UpdatedProductResponse> Update(UpdateProductRequest updateProductRequest);
        Task<CreatedProductResponse> GetById(int id);

    }
}