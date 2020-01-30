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
using agos_api.Models.StaticData;
using agos_api.Constants.Interpreter;

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
            var roleList = new List<string>()   // Список ролей
                {
                    "devAdmin", "admin", "helper", "guest"
                };

            // Достать все роли из базы
            var roles = roleManager.Roles.Select(x => x.Name).ToList();

            // Сравнить роли из списка и базы
            var roleDiff = roleList.Except(roles).ToList();

            // Если есть разница, то добавить не существующие роли из списка в базу
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

            #region WeekDay
            var fullDayList = new List<string>()
            {
                "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"
            };
            var shortDayList = new List<string>()
            {
                "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"
            };
            // List<string> WeekDaysKz = new List<string>()
            // {
            //     "Дүйсенбі", "Сейсенбі", "Сәрсенбі", "Бейсенбі", "Жұма", "Сенбі"
            // };

            // List<string> WeekDaysRu = new List<string>()
            // {
            //     "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"
            // };

            // List<string> WeekDaysEn = new List<string>()
            // {
            //     "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Satuday"
            // };
            // };

            var daysFullName = _dbContext.WeekDays.Select(x => x.DayFullName).ToList();
            var daysDiff = fullDayList.Except(daysFullName).ToList();
            if (daysDiff.Count() > 0)
            {
                for (int i = 0; i < daysDiff.Count(); i ++)
                {
                    var day = new WeekDay 
                    {
                        DayFullName = fullDayList[i],
                        DayShortName = shortDayList[i]
                    };
                    _dbContext.WeekDays.Add(day);
                }
            }
            #endregion

            #region TypeWeek
            // List<string> typeKz = new List<string>()
            //     {
            //         "есептегіш", "анықтауыш"
            //     };
            List<string> typeRu = new List<string>()
                {
                    "числитель", "знаминатель"
                };
            // List<string> typeEn = new List<string>()
            //     {
            //         "numerator", "denominator"
            //     };

            var typesWeek = _dbContext.TypeWeeks.Select(x => x.TypeWeekName).ToList();
            var typesWeekDiff = typeRu.Except(typesWeek).ToList();
            if (typesWeekDiff.Count() > 0)
            {
                foreach (var item in typeRu)
                {
                    var TypeWeek = new TypeWeek { TypeWeekName = item };
                    _dbContext.TypeWeeks.Add(TypeWeek);
                }
            }
            #endregion

            #region TypeLesson
            List<string> typeLessons = new List<string>()
            {
                "Лабораторная работа", "Теория", "Факультатив", "Практическая работа"
            };

            var typesLesson = _dbContext.TypeLessons.Select(x => x.TypeLessonName).ToList();
            var typesLessonDiff = typeLessons.Except(typesLesson).ToList();

            foreach (var item in typeLessons)
            {
                var TypeLesson = new TypeLesson { TypeLessonName = item };
                _dbContext.TypeLessons.Add(TypeLesson);
            }
            #endregion

            #region devUsers
            // Поиск пользователя в базе
            var chiefAdmin = userManager.Users.FirstOrDefault(x => x.UserName == "agos.vb@gmail.com");

            // Если таковой пользователь не имеется, то добавить его в общую таблицу всех пользователей AspNetUsers
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
                // Добавление пользователя
                var chiefAdminCreated = userManager.CreateAsync(chiefAdmin, "@G0Sik");
                chiefAdminCreated.Wait();

                // Добавление роли пользователя
                var chiefAdminRole = userManager.AddToRoleAsync(chiefAdmin, "devAdmin");
                chiefAdminRole.Wait();
            }

            // Если таковой пользователь не имеетя, то добавиль его в таблицу devUsers - администрация системы
            var opExisting = _dbContext.Users.Find(chiefAdmin.Id);
            if (opExisting == null)
            {
                var opNew = new devUser(chiefAdmin);
                _dbContext.devUsers.Add(opNew);
            }
            #endregion

            _dbContext.SaveChanges();
        }
    }
}