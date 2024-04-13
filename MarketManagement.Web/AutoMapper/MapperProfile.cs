﻿

using AutoMapper;
using MarketManagement.Core.Entities;
using MarketManagement.Core.Entities.ViewModels;
using MarketManagement.Web.Validations;

namespace MarketManagement.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap(); ;
            CreateMap<Product, CreateProductViewModel>().ReverseMap();
            CreateMap<Transaction, SalesViewModel>().ReverseMap();

        }
    }
}
