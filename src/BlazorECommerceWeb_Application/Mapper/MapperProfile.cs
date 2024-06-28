using AutoMapper;
using BlazorECommerceWeb_Application.DTOs;
using BlazorECommerceWeb_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Application.Mapper;
public class MapperProfile:Profile
{

    public MapperProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
