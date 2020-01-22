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
                var roleList = new List<string>()   /// Список ролей
                {
                    "devAdmin", "admin", "helper", "guest"
                };

                /// Достать все роли из базы
                var roles = roleManager.Roles.Select(x => x.Name).ToList();

                /// Сравнить роли из списка и базы
                var roleDiff = roleList.Except(roles).ToList();

                /// Если есть разница, то добавить не существующие роли из списка в базу
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
                /// Поиск пользователя в базе
                var chiefAdmin = userManager.Users.FirstOrDefault(x => x.UserName == "agos.vb@gmail.com");

                /// Если таковой пользователь не имеется, то добавить его в общую таблицу всех пользователей AspNetUsers
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
                    /// Добавление пользователя
                    var chiefAdminCreated = userManager.CreateAsync(chiefAdmin, "@G0Sik");
                    chiefAdminCreated.Wait();

                    /// Добавление роли пользователя
                    var chiefAdminRole = userManager.AddToRoleAsync(chiefAdmin, "devAdmin");
                    chiefAdminRole.Wait();
                }

                /// Если таковой пользователь не имеетя, то добавиль его в таблицу devUsers - администрация системы
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