﻿using AutoMapper;
using BusinessObjects.Models;
using DTOs;
using DTOs.Categories;
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
        }
    }
}
