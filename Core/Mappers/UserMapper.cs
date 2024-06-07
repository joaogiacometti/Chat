using AutoMapper;
using Core.Dtos.User;
using Core.Models;

namespace Core.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<UserRegisterDto, User>().ReverseMap();
    }
}