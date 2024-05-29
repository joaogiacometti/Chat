using Core.Interfaces.Repositories;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Configurations;

public static class RepositoriesConfig
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddTransient<IAccountRepository, AccountRepository>();
    }   
}