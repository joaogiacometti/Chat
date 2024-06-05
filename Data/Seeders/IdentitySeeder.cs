using Core.Interfaces.Seeders;
using Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Data.Seeders;

public class IdentitySeeder(UserManager<User> userManager, RoleManager<Role> roleManager)
    : IIdentitySeeder
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly RoleManager<Role> _roleManager = roleManager;

    public async Task SeedRoles()
    {
        if (!await _roleManager.RoleExistsAsync("User"))
        {
            var role = new Role()
            {
                Name = "User",
                NormalizedName = "USER",
            };

            await _roleManager.CreateAsync(role);
        }

        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            var role = new Role()
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
            };

            await _roleManager.CreateAsync(role);
        }
    }

    public async Task SeedUsers()
    {
        if (await _userManager.FindByEmailAsync("user@user.com") == null)
        {
            var user = new User()
            {
                UserName = "user@user.com",
                NormalizedUserName = "USER@USER.COM",
                Email = "user@user.com",
                NormalizedEmail = "USER@USER.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
            };

            var result = await _userManager.CreateAsync(user, "Use#!fadwr123!");

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
        }

        if (await _userManager.FindByEmailAsync("admin@admin.com") == null)
        {
            var user = new User()
            {
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
            };

            var result = await _userManager.CreateAsync(user, "Ud1DAWAse#!fadwr123");

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}