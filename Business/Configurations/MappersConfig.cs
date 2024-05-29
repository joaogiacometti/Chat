using AutoMapper;
using Core.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Configurations;

public static class MappersConfig
{
    public static void ConfigureMappers(this IServiceCollection services)
    {
        services.AddTransient(provider => new MapperConfiguration(mc =>
        {
            mc.AddProfile<AccountMapper>();
        }).CreateMapper());
    }
}