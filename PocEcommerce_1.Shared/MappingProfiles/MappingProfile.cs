using AutoMapper;
using PocEcommerce_1.DTOs;
using PocEcommerce_1.Entities;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.Shared.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserToInsertViewModel, UserDTO>().ReverseMap();

            CreateMap<UserViewModel, UserDTO>().ReverseMap();

            CreateMap<UserDTO, User>().ReverseMap();

            CreateMap<CourseToInsertViewModel, CourseDTO>().ReverseMap();

            CreateMap<CourseViewModel, CourseDTO>().ReverseMap();

            CreateMap<CourseDTO, Course>().ReverseMap();

            CreateMap<OrderToInsertViewModel, OrderDTO>()
                .ForMember(dest => dest.CourseDTO, src => src.MapFrom(opt => opt.CourseViewModel));

            CreateMap<OrderViewModel, OrderDTO>()
                .ForMember(dest => dest.CourseDTO, src => src.MapFrom(opt => opt.CourseViewModel));

            CreateMap<OrderDTO, Order>().ReverseMap();
        }
    }
}
