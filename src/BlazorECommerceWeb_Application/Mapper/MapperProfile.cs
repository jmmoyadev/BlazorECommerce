using AutoMapper;
using BlazorECommerceWeb_Application.DTOs;
using BlazorECommerceWeb_Domain.Entities;

namespace BlazorECommerceWeb_Application.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();

        CreateMap<Product, ProductDto>().ReverseMap();

        CreateMap<ProductPrice, ProductPriceDto>().ReverseMap();
    }
}
