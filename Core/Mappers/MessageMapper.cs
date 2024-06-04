using AutoMapper;
using Core.Dtos;
using Core.Models;

namespace Core.Mappers;

public class MessageMapper : Profile
{
    public MessageMapper()
    {
        CreateMap<MessageMutateDto, Message>().ReverseMap();
        CreateMap<MessageDto, Message>().ReverseMap();
    }
}