using AutoMapper;
using KimlikDogrulamaCase.DTOs;
using KimlikDogrulamaCase.Entities;

namespace KimlikDogrulamaCase.BLL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
