using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Business.Configurations;

public static class CoreConfig
{
    public static void ConfigureApp(this IServiceCollection service, IConfiguration config)
    {
        service.ConfigureConnection(config);
    }
}