using AutoMapper;
using Core.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Configurations;

public static class MapperConfig
{
    public static void ConfigureMapper(this IServiceCollection service)
    {
        service.AddTransient(provider => new MapperConfiguration(mc =>
        {
            mc.AddProfile<MessageMapper>();
            mc.AddProfile<ChatMapper>();
        }).CreateMapper());
    }
}