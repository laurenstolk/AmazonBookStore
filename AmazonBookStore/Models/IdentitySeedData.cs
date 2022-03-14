using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AmazonBookStore.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "413ExtraYeetPeriod(t)!";
        
        public static async void EnsurePopulated (IApplicationBuilder app)
        {
            AppIdentityDBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByIdAsync(adminUser);

            if (user == null)
            {
                user = new IdentityUser(adminUser);

                user.Email = "admin@yeet.com";
                user.PhoneNumber = "303-471-9966";

                await userManager.CreateAsync(user, adminPassword);
            }

        }

    }
}
