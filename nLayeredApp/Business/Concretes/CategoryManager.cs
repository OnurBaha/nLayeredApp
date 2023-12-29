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
        ICategoryDal _categoryDal;
        IMapper _mapper;
        CategoryBusinessRules _businessRules;

        public CategoryManager(CategoryBusinessRules businessRules, ICategoryDal categoryDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
        {
            Category category = _mapper.Map<Category>(createCategoryRequest);
            Category createdCategory = await _categoryDal.AddAsync(category);
            CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(createdCategory);
            return createdCategoryResponse;
        }

        public async Task<DeletedCategoryResponse> Delete(DeleteCategoryRequest deleteCategoryRequest)
        {
            var data = await _categoryDal.GetAsync(i => i.Id == deleteCategoryRequest.Id);
            _mapper.Map(deleteCategoryRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _categoryDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedCategoryResponse>(result);
            return result2;
        }

        public async Task<CreatedCategoryResponse> GetById(int id)
        {
            var result = await _categoryDal.GetAsync(c => c.Id == id);
            Category mappedCategory = _mapper.Map<Category>(result);
            CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(mappedCategory);
            return createdCategoryResponse;
        }


        public async Task<IPaginate<GetListCategoryResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _categoryDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListCategoryResponse>>(data);
            return result;
        }


        public async Task<UpdatedCategoryResponse> Update(UpdateCategoryRequest updateCategoryRequest)
        {
            var data = await _categoryDal.GetAsync(i => i.Id == updateCategoryRequest.Id);
            _mapper.Map(updateCategoryRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _categoryDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedCategoryResponse>(data);
            return result;
        }
    }
}
