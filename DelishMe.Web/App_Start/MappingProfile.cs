﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DelishMe.Web.Dtos;
using DelishMe.Web.Models;

namespace DelishMe.Web.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Dish, DishDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Category, CategoryDto>();


            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<DishDto, Dish>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}