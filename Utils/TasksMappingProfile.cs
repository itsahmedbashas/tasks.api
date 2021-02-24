using System.Runtime.InteropServices;
using AutoMapper;
using Tasks.API.Models;
using Tasks.API.ViewModels;

namespace Tasks.API.Utils
{

    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<UserModel, UserViewModel>()
            .ForMember(dest => dest.UName, opt => opt.MapFrom(sou => sou.UserName))
            .ForMember(dest => dest.UFullName, opt => opt.MapFrom(sou => sou.UserFullName))
            .ForMember(dest => dest.UEmail, opt => opt.MapFrom(sou => sou.UserEmail))
            .ForMember(dest => dest.UPhoneNumber, opt => opt.MapFrom(sou => sou.UserPhoneNumber))
            .ForMember(dest => dest.UGender, opt => opt.MapFrom(sou => sou.UserGender))
            .ForMember(dest => dest.UPassword, opt => opt.MapFrom(sou => sou.UserPassword))
            .ReverseMap();
        }
    }
}