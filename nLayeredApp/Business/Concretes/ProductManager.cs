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


        public ProductManager(IProductDal productDal, IMapper mapper, ProductBusinessRules businessRules)
        {
            _productDal = productDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest)
        {
            await _businessRules.EachCategoryCanContainMax20Products(createProductRequest.CategoryId);
            Product product = _mapper.Map<Product>(createProductRequest);
            Product createdProduct = await _productDal.AddAsync(product);
            CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(createdProduct);
            return createdProductResponse;
        }

        public async Task<IPaginate<GetListProductResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _productDal.GetListAsync(
                include: p => p.Include(p => p.Category),
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
                );
            var result = _mapper.Map<Paginate<GetListProductResponse>>(data);
            return result;
        }
    }
}