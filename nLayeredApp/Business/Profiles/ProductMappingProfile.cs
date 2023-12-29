using Business.Dtos.Requests;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Core.Persistence.Paging;

namespace Business.Dtos.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, CreatedProductResponse>();
            //CreateMap<Product, GetListProductResponse>();

            //CreateMap<IPaginate<Product>, GetListProductResponse>();
            //CreateMap<Product, ProductListDto>();

            CreateMap<Product, DeleteProductRequest>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();

            CreateMap<Product, DeletedProductResponse>().ReverseMap();
            CreateMap<Product, UpdatedProductResponse>().ReverseMap();

            CreateMap<Product, GetListProductResponse>()
                .ForMember(destinationMember: p => p.CategoryName,
                    memberOptions: opt => opt.MapFrom(p => p.Category.Name)).ReverseMap();
            CreateMap<Paginate<Product>, Paginate<GetListProductResponse>>().ReverseMap();
        }
    }
}