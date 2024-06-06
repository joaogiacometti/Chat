using AutoMapper;
using Core.Dtos;
using Core.Models;

namespace Core.Mappers;

public class MessageMapper : Profile
{
    public MessageMapper()
    {
        CreateMap<MessageDto, Message>().ReverseMap();
        CreateMap<MessageUpdateDto, Message>().ReverseMap();
        CreateMap<MessageCreateDto, Message>().ReverseMap();
    }
}