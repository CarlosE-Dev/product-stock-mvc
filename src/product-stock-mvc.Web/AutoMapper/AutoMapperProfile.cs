using AutoMapper;
using product_stock_mvc.Business.Models;
using product_stock_mvc.Web.DTOs;

namespace product_stock_mvc.Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Provider, ProviderDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
