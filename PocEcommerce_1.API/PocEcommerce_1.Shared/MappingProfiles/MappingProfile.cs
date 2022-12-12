using AutoMapper;
using PocEcommerce_1.DTOs;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.Shared.MappingProfiles
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserToInsertViewModel, UserDTO>().ReverseMap();
        }
    }
}
