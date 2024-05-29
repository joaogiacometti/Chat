using AutoMapper;
using Core.Dtos;
using Core.Models;

namespace Core.Mappers;

public class AccountMapper : Profile
{
    public AccountMapper()
    {
        CreateMap<Account, AccountDto>().ReverseMap();
        CreateMap<Account, AccountRegisterDto>().ReverseMap();
        CreateMap<Account, AccountUpdateDto>().ReverseMap();
    }
}