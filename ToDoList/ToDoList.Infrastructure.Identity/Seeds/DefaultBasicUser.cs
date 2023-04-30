using Microsoft.AspNetCore.Identity;
using ToDoList.Application.Enums;
using ToDoList.Infrastructure.Identity.Models;

namespace ToDoList.Infrastructure.Identity.Seeds
{
    public static class DefaultBasicUser
    {
        //public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        //{
        //    //Seed Default User
        //    var defaultUser = new ApplicationUser
        //    {
        //        UserName = "Admin",
        //        Email = "Admin@Admin.com",
        //        FirstName = "AmirReza",
        //        PhoneNumber = "091270000000",
        //        LastName = "Azadi",
        //        EmailConfirmed = true,
        //        PhoneNumberConfirmed = true

        //    };
        //    if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
        //    {
        //        var user = await userManager.FindByEmailAsync(defaultUser.Email);
        //        if (user == null)
        //        {
        //            await userManager.CreateAsync(defaultUser, "@mirReza123");
        //            await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
        //        }

        //    }
        //}
    }
}
