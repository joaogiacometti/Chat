using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Business.Configurations;

public static class ConnectionConfig
{
    public static void ConfigureConnection(this IServiceCollection service, IConfiguration config)
    {
        var conn = config.GetConnectionString("Default");

        if (string.IsNullOrEmpty(conn))
        {
            throw new ArgumentNullException(nameof(conn));
        }

        service.AddDbContext<ChatContext>(op =>
            op.UseSqlServer(conn, b => b.MigrationsAssembly("Api")));
    }
}