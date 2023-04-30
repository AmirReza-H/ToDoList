using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoList.Application.Enums;
using ToDoList.Infrastructure.Identity.Models;

namespace ToDoList.Infrastructure.Identity.Seeds
{
    public class IdentityRequirementSeed : IHostedService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityRequirementSeed(IServiceScopeFactory serviceScopeFactory )
        {
            _userManager = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            _roleManager = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>(); 
        }

        private async Task DefaultBasicUserAndRole()
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "Admin",
                Email = "Admin@Admin.com",
                FirstName = "AmirReza",
                LastName = "H",
                PhoneNumber = "091270000000",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true

            };
            if (_userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                var user = await _userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await this.DefaultRoles();
                    await _userManager.CreateAsync(defaultUser, "@mirReza123");
                    await _userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                }

            }
        }

        private async Task DefaultRoles()
        {
            //Seed Roles
            await _roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await _roleManager.CreateAsync(new IdentityRole(Roles.Client.ToString()));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return DefaultBasicUserAndRole();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
