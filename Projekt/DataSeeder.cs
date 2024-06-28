using Microsoft.AspNetCore.Identity;

namespace Projekt;
public static class DataSeeder
{
    public static async Task SeedRolesAndAdminUser(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        var roles = new[] { "admin", "user" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        var adminUser = new IdentityUser
        {
            UserName = "admin",
            Email = "admin@example.com"
        };

        if (await userManager.FindByNameAsync(adminUser.UserName) == null)
        {
            var result = await userManager.CreateAsync(adminUser, "AdminPassword123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "admin");
            }
        }
    }
}

