using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Core.Persistence.Paging;
using Entities.Concretes;

namespace Business.AutoMapper.Profiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<IPaginate<Product>, IPaginate<GetListCustomerResponse>>().ReverseMap();

            CreateMap<Customer, CreateCustomerRequest>().ReverseMap();
            CreateMap<Customer, DeleteCustomerRequest>().ReverseMap();
            CreateMap<Customer, UpdateCustomerRequest>().ReverseMap();

            CreateMap<Customer, CreatedCustomerResponse>().ReverseMap();
            CreateMap<Customer, DeletedCustomerResponse>().ReverseMap();
            CreateMap<Customer, UpdatedCustomerResponse>().ReverseMap();

        }
    }
}