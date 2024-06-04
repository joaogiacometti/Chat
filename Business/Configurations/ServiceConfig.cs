using Business.Services;
using Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Configurations;

public static class ServiceConfig
{
    public static void ConfigureService(this IServiceCollection service)
    {
        service.AddTransient<IMessageService, MessageService>();
    }
}