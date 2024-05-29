using Business.Services;
using Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Configurations;

public static class ServicesConfig
{
    public static void ConfigureServices(this IServiceCollection service)
    {
        service.AddTransient<IAccountService, AccountService>();
    }
}