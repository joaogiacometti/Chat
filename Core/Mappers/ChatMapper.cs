using AutoMapper;
using Core.Dtos;
using Core.Models;

namespace Core.Mappers;

public class ChatMapper : Profile
{
    public ChatMapper()
    {
        CreateMap<ChatDto, Chat>().ReverseMap();
        CreateMap<ChatCreateDto, Chat>().ReverseMap();
        CreateMap<ChatUpdateDto, Chat>().ReverseMap();
        
    }
}