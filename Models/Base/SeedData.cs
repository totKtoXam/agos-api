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

            // _dbContext.Database.EnsureDeleted();
            // _dbContext.Database.EnsureCreated();

            #region  Roles
                var roleList = new List<string>()
                {
                    "devAdmin", "admin", "helper", "guest"
                };
                var roles = roleManager.Roles.Select(x => x.Name).ToList();
                var roleDiff = roleList.Except(roles).ToList();
                if (roleDiff.Count() > 0)
                {
                    foreach (var item in roleDiff)
                    {
                        var role = new IdentityRole { Name = item };
                        var t = roleManager.CreateAsync(role);
                        t.Wait();
                    }
                }
            #endregion
            
            #region WeekDays
                // var dayRusList = new List<string>()
                // {
                //     "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"
                // };
                // var dayEngList = new List<string>()
                // {
                //     "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"
                // };
                // var dayKzList = new List<string>()
                // {
                //     "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"
                // };
                // var daysFullName = _dbContext.WeekDays.Select(x => x.DayFullName).ToList();
                // var daysDiff = roleList.Except(roles).ToList();
                // if (roleDiff.Count() > 0)
                // {
                //     foreach (var item in roleDiff)
                //     {
                //         var role = new IdentityRole { Name = item };
                //         var t = roleManager.CreateAsync(role);
                //         t.Wait();
                //     }
                // }
            #endregion

            #region devUsers
                var chiefAdmin = userManager.Users.FirstOrDefault(x => x.UserName == "agos.vb@gmail.com");
                if (chiefAdmin == null)
                {
                    chiefAdmin = new ApplicationUser
                    {
                        Email = "agos.vb@gmail.com",
                        UserName = "agos.vb@gmail.com",
                        Surname = "devAdmin",
                        Name = "devAdmin",
                        EmailConfirmed = true
                    };
                    var chiefAdminCreated = userManager.CreateAsync(chiefAdmin, "@G0Sik");
                    chiefAdminCreated.Wait();
                    var chiefAdminRole = userManager.AddToRoleAsync(chiefAdmin, "devAdmin");
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
            #endregion
        }
    }
}