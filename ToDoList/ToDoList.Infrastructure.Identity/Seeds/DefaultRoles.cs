using Microsoft.AspNetCore.Identity;
using ToDoList.Application.Enums;
using ToDoList.Infrastructure.Identity.Models;

namespace ToDoList.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Client.ToString()));
        }
    }
}
