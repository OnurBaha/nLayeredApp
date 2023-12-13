using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using Core.Persistence.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        IMapper _mapper;
        CategoryBusinessRules _categoryBusinessRules;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<IPaginate<GetListCategoryResponse>> GetListAsync(PageRequest pageRequest)
        {
            var categoryList = await _categoryDal.GetListAsync();
            var mappedList = _mapper.Map<Paginate<GetListCategoryResponse>>(categoryList);
            return mappedList;
        }

        public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
        {
            await _categoryBusinessRules.MaximumCategoryCountIsTen();
            Category category = _mapper.Map<Category>(createCategoryRequest);
            var createdCategory = await _categoryDal.AddAsync(category);
            CreatedCategoryResponse result = _mapper.Map<CreatedCategoryResponse>(createdCategory);
            return result;
        }

    }
}