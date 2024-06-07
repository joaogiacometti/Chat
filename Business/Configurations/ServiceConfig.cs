using Business.Services;
using Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;

namespace Business.Configurations;

public static class ServiceConfig
{
    public static void ConfigureService(this IServiceCollection service)
    {
        service.AddTransient<IMessageService, MessageService>();
        service.AddTransient<IChatService, ChatService>();
        service.AddTransient<IUserService, UserService>();
    }
}