using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using agos_api.Models.Base;
using agos_api.Models.Users;

namespace agos_api.Models.Base
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var _dbContext = serviceProvider.GetRequiredService<AppDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            _dbContext.Database.EnsureCreated();

            var roleList = new List<string>()
            {
                "admin", "helper", "guest"
            };
            var roles = roleManager.Roles.Select(x => x.Name).ToList();
            // Сравнивает списки и разницу добавляет в БД
            var roleDiff = roleList.Except(roles).ToList();
            if (roleDiff.Count() > 0)
            {
                // Связывает роли с входной группой
                foreach (var item in roleDiff)
                {
                    var role = new IdentityRole { Name = item };
                    var t = roleManager.CreateAsync(role);
                    t.Wait();
                }
            }
            
            var chiefAdmin = userManager.Users.FirstOrDefault(x => x.UserName == "agos.vb@gmail.com");
            if (chiefAdmin == null)
            {
                chiefAdmin = new ApplicationUser
                {
                    Email = "agos.vb@gmail.com",
                    UserName = "chiefAdmin",
                    Surname = "chiefAdmin",
                    Name = "chiefAdmin",
                    EmailConfirmed = true
                };
                var chiefAdminCreated = userManager.CreateAsync(chiefAdmin, "P@ssw0rd");
                chiefAdminCreated.Wait();
                var chiefAdminRole = userManager.AddToRoleAsync(chiefAdmin, "admin");
                chiefAdminRole.Wait();
            }

            var opExisting = _dbContext.Users.Find(chiefAdmin.Id);
                if (opExisting != null)
                {
                    var opNew = new devUser(chiefAdmin);
                    _dbContext.devUsers.Add(opNew);
                    var opSave = _dbContext.SaveChangesAsync();
                    opSave.Wait();
                }
        }
    }
}