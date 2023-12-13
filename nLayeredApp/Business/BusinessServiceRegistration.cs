using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Concretes;
using Business.Rules;

namespace Business
{

    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<ProductBusinessRules>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }

}

// customer ıd, name, contact name, city, country
// contact name tekrar edemez.
// bir şehirden maks 10 müşteri kabul ediyoruz sisteme.
//customer, companyname, contactname, city, country - bununla ilgili tüm CRUDları yaz. Insert update, delete, get



//using Business.Abstracts;
//using Business.Concretes;
//using Business.Rules;
//using DataAccess.Abstracts;
//using DataAccess.Concretes;
//using DataAccess.Contexts;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace Business;

//public static class BusinessServiceRegistration
//{
//    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
//    {
//        services.AddScoped<IProductService, ProductManager>();
//        services.AddScoped<ICategoryService, CategoryManager>();
//        services.AddAutoMapper(Assembly.GetExecutingAssembly());

//        return services;
//    }

//    public static IServiceCollection AddSubClassesOfType(
//      this IServiceCollection services,
//      Assembly assembly,
//      Type type,
//      Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
//  )
//    {
//        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
//        foreach (var item in types)
//            if (addWithLifeCycle == null)
//                services.AddScoped(item);

//            else
//                addWithLifeCycle(services, type);
//        return services;
//    }
//}