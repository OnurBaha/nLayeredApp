using Business.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business.Rules;

namespace Business.Rules
{
    public class ProductBusinessRules : BaseBusinessRules
    {
        private readonly IProductDal _productDal;

        public ProductBusinessRules(IProductDal productDal)
        {
            _productDal = productDal;
        }
        //bi kategoride max 20 olabilir
        public async Task EachCategoryCanContainMax20Products(int categoryId)
        {
            var result = await _productDal.GetListAsync(
                predicate: p => p.CategoryId == categoryId,
                size: 25
                );

            if (result.Count >= 20)
            {
                throw new BusinessException(BusinessMessages.CategoryProductLimit);
            }
        }
    }
}