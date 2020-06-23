using AutoMapper;
using eccomerce_webapi.Models;
using eccomerce_webapi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eccomerce_webapi.AutomapperProfile
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, CustomerViewModel>()
            .ReverseMap();
        }
    }
}
