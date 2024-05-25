using System;
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
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
                }
    }
}