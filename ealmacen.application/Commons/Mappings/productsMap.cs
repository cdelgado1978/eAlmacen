using AutoMapper;
using eAlmacen.Application.Products.Commands;
using eAlmacen.Application.Products.Responses;
using eAlmacen.Domain.Entities;

namespace eAlmacen.Application.Commons.Mappings;

public class ProductsMap : Profile
{
    public ProductsMap()
    {
        CreateMap<CreateProductsCommand, Product>(MemberList.None);
        CreateMap<Product, ProductsResponseModel>(MemberList.None);

    }
}