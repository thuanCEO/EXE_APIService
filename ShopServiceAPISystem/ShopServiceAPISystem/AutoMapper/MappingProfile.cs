using AutoMapper;
using BusinessObjects.Models;
using DTOs;
using DTOs.Categories;
using DTOs.Feedbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServiceAPISystem.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<ProductDTO, Product>();
            CreateMap<BlogDTO, Blog>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderDetailDTO, OrderDetail>();
            CreateMap<RequestCategoryDTO, Category>();
            CreateMap<ResponseCategoryDTO, Category>();
            CreateMap<Feedback, ResponseFeedbackDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));
            CreateMap<RequestFeedbackDTO, Feedback>();
        }
    }
}
