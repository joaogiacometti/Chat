namespace Core.Interfaces.Seeders;

public interface IIdentitySeeder
{
    Task SeedRoles();
    Task SeedUsers();
}