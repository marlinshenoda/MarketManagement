﻿

using AutoMapper;
using MarketManagement.Core.Entities;
using MarketManagement.Core.Entities.ViewModels;

namespace MarketManagement.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductViewModel>();
            //CreateMap<Vehicle, CreateVehicleViewModel>().ReverseMap();
            // CreateMap<Vehicle, VehicleEditViewModel>().ReverseMap();
            //CreateMap<Vehicle, VehicleDetailsViewModel>();
             
        }
    }
}