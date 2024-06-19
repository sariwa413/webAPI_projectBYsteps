using AutoMapper;
using DTO;
using Entities;

namespace webAPI_projectBYsteps
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Category, categoryDTO>().ReverseMap();
            CreateMap<Product, productDTO>().ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.Category.CategoryId)).ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Order, orderDTO>().ReverseMap();
            CreateMap<UserLoginDTO, User>().ReverseMap();
        }
    }
} 
