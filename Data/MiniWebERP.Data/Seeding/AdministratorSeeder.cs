namespace MiniWebERP.Data.Seeding
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MiniWebERP.Common;
    using MiniWebERP.Data.Models;

    public class AdministratorSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var rootUser = new RootUser();
            configuration.GetSection("Administrator").Bind(rootUser);

            var adminUser = await userManager.FindByNameAsync(rootUser.UserName);

            if (adminUser == null)
            {
                var admin = new ApplicationUser { UserName = rootUser.UserName, Email = rootUser.Email };

                var result = await userManager.CreateAsync(admin, rootUser.Password);

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
