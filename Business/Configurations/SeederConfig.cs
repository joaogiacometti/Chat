using Core.Interfaces.Seeders;
using Data.Seeders;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Configurations;

public static class SeederConfig
{
    public static void ConfigureSeeder(this IServiceCollection service)
    {
        service.AddTransient<IIdentitySeeder, IdentitySeeder>();
    }

    public static async Task SeedData(this IServiceProvider service)
    {
        using var scope = service.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<IIdentitySeeder>();
        await seeder.SeedRoles();
        await seeder.SeedUsers();
    }
}