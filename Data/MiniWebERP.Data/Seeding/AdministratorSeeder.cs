namespace MiniWebERP.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using MiniWebERP.Common;
    using MiniWebERP.Data.Models;

    public class AdministratorSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var adminUser = await userManager.FindByNameAsync("admin");

            // TODO: get from json User an password
            if (adminUser == null)
            {
                var admin = new ApplicationUser { UserName = "admin@weberp.com", Email = "admin@weberp.com" };

                var result = await userManager.CreateAsync(admin, "qwe@123");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, GlobalConstants.AdministratorRoleName).GetAwaiter().GetResult();
                }
                else
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
