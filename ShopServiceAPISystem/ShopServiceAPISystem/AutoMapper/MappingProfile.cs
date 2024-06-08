using AutoMapper;
using BusinessObjects.Models;
using DTOs.Create;
using DTOs.Update;

namespace ShopServiceAPISystem.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<CreateBlogDTO, Blog>();
            CreateMap<UpdateBlogDTO, Blog>();
            CreateMap<CreateOrderDTO, Order>();
            CreateMap<UpdateOrderDTO, Order>();
            CreateMap<CreateOrderDetailDTO, OrderDetail>();
            CreateMap<UpdateOrderDetailDTO, OrderDetail>();
        }
    }
}
