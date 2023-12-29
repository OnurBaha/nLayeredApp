using System;
using Azure.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Core.Persistence.Paging;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        IMapper _mapper;
        ProductBusinessRules _businessRules;

        public ProductManager(ProductBusinessRules businessRules, IProductDal productDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _productDal = productDal;
            _mapper = mapper;
        }

        public async Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest)
        {
            Product product = _mapper.Map<Product>(createProductRequest);
            Product createdProduct = await _productDal.AddAsync(product);
            CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(createdProduct);
            return createdProductResponse;
        }

        public async Task<DeletedProductResponse> Delete(DeleteProductRequest deleteProductRequest)
        {
            var data = await _productDal.GetAsync(i => i.Id == deleteProductRequest.Id);
            _mapper.Map(deleteProductRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _productDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedProductResponse>(result);
            return result2;
        }

        public async Task<CreatedProductResponse> GetById(int id)
        {
            var result = await _productDal.GetAsync(p => p.Id == id);
            Product mappedProduct = _mapper.Map<Product>(result);
            CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(mappedProduct);
            return createdProductResponse;
        }


        public async Task<IPaginate<GetListProductResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _productDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListProductResponse>>(data);
            return result;
        }


        public async Task<UpdatedProductResponse> Update(UpdateProductRequest updateProductRequest)
        {
            var data = await _productDal.GetAsync(i => i.Id == updateProductRequest.Id);
            _mapper.Map(updateProductRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _productDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedProductResponse>(data);
            return result;
        }
    }
}