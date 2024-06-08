using AutoMapper;
using BusinessObjects.Models;
using DTOs;
using DTOs.Cartproducts;
using DTOs.Carts;
using DTOs.Categories;
using DTOs.Feedbacks;
using DTOs.Services;
using DTOs.shippings;
using DTOs.vouchers;
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
            CreateMap<RequestCategoryDTO, Category>();
            CreateMap<ResponseCategoryDTO, Category>();
            CreateMap<Feedback, ResponseFeedbackDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));
            CreateMap<RequestFeedbackDTO, Feedback>();
            CreateMap<ResponseServiceDTO, BusinessObjects.Models.Service>();
            CreateMap<RequestServiceDTO, BusinessObjects.Models.Service>();
            CreateMap<ResponseShippingDTO, Shipping>();
            CreateMap<RequestShippingDTO, Shipping>();
            CreateMap<RequestVoucherDTO, Voucher>();
            CreateMap<ResponseVoucherDTO, Voucher>();
            CreateMap<Cart, ResponseCartDTO>()
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName));
            CreateMap<RequestCartDTO, Cart>();
            CreateMap<CartProduct, ResponseCartProductDTO>()
           .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));
            CreateMap<RequestCartProductDTO, CartProduct>();
        }
    }
}
