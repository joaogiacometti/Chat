using Core.Interfaces.Repositories;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Configurations;

public static class RepositoryConfig
{
    public static void ConfigureRepository(this IServiceCollection service)
    {
        service.AddTransient<IMessageRepository, MessageRepository>();
    }
}