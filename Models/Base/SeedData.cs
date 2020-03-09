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
using agos_api.Models.Organizations;

namespace agos_api.Models.Base
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var _dbContext = serviceProvider.GetRequiredService<AppDbContext>();
            var _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // _dbContext.Database.EnsureDeleted();
            // _dbContext.Database.EnsureCreated();

            #region  Roles
            var roleList = new List<string>()   // Список ролей
                {
                    "devAdmin", "orgAdmin", "orgHelper", "guest"
                };

            // Достать все роли из базы
            var roles = _roleManager.Roles.Select(x => x.Name).ToList();

            // Сравнить роли из списка и базы
            var roleDiff = roleList.Except(roles).ToList();

            // Если есть разница, то добавить не существующие роли из списка в базу
            if (roleDiff.Count() > 0)
            {
                foreach (var item in roleDiff)
                {
                    var role = new IdentityRole { Name = item };
                    var t = _roleManager.CreateAsync(role);
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


            if (typesLessonDiff.Count() > 0)
            {
                foreach (var item in typesLessonDiff)
                {
                    var TypeLesson = new TypeLesson { TypeLessonName = item };
                    _dbContext.TypeLessons.Add(TypeLesson);
                }
            }
            #endregion

            #region DevUsers
            // Поиск пользователя в базе
            var chiefAdmin = _userManager.Users.FirstOrDefault(x => x.UserName == "agos.vb@gmail.com");

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
                var chiefAdminCreated = _userManager.CreateAsync(chiefAdmin, "@G0Sik");
                chiefAdminCreated.Wait();

                // Добавление роли пользователя
                var chiefAdminRole = _userManager.AddToRoleAsync(chiefAdmin, "devAdmin");
                chiefAdminRole.Wait();
            }

            // Если таковой пользователь не имеетя, то добавиль его в таблицу DevUsers - администрация системы
            var opExisting = _dbContext.DevUsers.FirstOrDefault(x => x.DevUserId == chiefAdmin.Id);
            if (opExisting == null)
            {
                var opNew = new DevUser
                {
                    DevUserId = chiefAdmin.Id,
                    IIN = "123456789012",
                    Position = "HeaderAdmin"
                };
                // opNew.User = chiefAdmin;
                _dbContext.DevUsers.Add(opNew);
            }
            #endregion

            #region _TEST_ StudyOrganizations
                var studyOrg = _dbContext.StudyOrganizations.FirstOrDefault(x => x.BIN == "123456789012");

                if (studyOrg == null)
                {
                    studyOrg = new StudyOrganization
                    {
                        OfficialName = "ГККП Политехка",
                        ShortName = "АПК",
                        AddressName = "Бейбитшилик",
                        NumOfHome = 39,
                        City = "Астана",
                        Key = "1-АПК-АСТАНА",
                        BIN = "123456789012"
                    };

                    _dbContext.StudyOrganizations.Add(studyOrg);
                }
            #endregion

            #region _TEST_ UserOrganizations
                #region orgAdminTestUser@agos.vb
                var orgAdminUser = _userManager.Users.FirstOrDefault(x => x.UserName == "orgAdminTestUser@agos.vb");

                if (orgAdminUser == null)
                {
                    orgAdminUser = new ApplicationUser
                    {
                        Email = "orgAdminTestUser@agos.vb",
                        UserName = "orgAdminTestUser@agos.vb",
                        Surname = "orgAdmin",
                        Name = "orgAdmin",
                        EmailConfirmed = true
                    };
                    // Добавление пользователя
                    var orgAdminUserCreated = _userManager.CreateAsync(orgAdminUser, "@G0Sik");
                    orgAdminUserCreated.Wait();

                    // Добавление роли пользователя
                    var orgAdminUserRole = _userManager.AddToRoleAsync(orgAdminUser, "orgAdmin");
                    orgAdminUserRole.Wait();
                }

                // Если таковой пользователь не имеетя, то добавиль его в таблицу DevUsers - администрация системы
                var orgAdminUserExisting = _dbContext.UserOrganizations
                                                            .Include(x => x.User)
                                                            .FirstOrDefault(x => x.User.Id == orgAdminUser.Id);
                if (orgAdminUserExisting == null)
                {
                    var orgAdminUserNew = new UserOrganization(orgAdminUser, studyOrg);
                    // orgAdminUserNew.StudyOrganization = studyOrg;
                    _dbContext.UserOrganizations.Add(orgAdminUserNew);
                }
                #endregion
            
                #region orgHelperTestUser@agos.vb
                    var orgHelperUser = _userManager.Users.FirstOrDefault(x => x.UserName == "orgHelperTestUser@agos.vb");

                    if (orgHelperUser == null)
                    {
                        orgHelperUser = new ApplicationUser
                        {
                            Email = "orgHelperTestUser@agos.vb",
                            UserName = "orgHelperTestUser@agos.vb",
                            Surname = "orgHelper",
                            Name = "orgHelper",
                            EmailConfirmed = true
                        };
                        // Добавление пользователя
                        var orgHelperUserCreated = _userManager.CreateAsync(orgHelperUser, "@G0Sik");
                        orgHelperUserCreated.Wait();

                        // Добавление роли пользователя
                        var orgHelperUserRole = _userManager.AddToRoleAsync(orgHelperUser, "orgHelper");
                        orgHelperUserRole.Wait();
                    }

                    // Если таковой пользователь не имеетя, то добавиль его в таблицу DevUsers - администрация системы
                    var orgHelperUserExisting = _dbContext.UserOrganizations
                                                                    .Include(x => x.User)
                                                                    .FirstOrDefault(x => x.Id == orgHelperUser.Id);
                    if (orgHelperUserExisting == null)
                    {
                        var orgHelperUserNew = new UserOrganization(orgHelperUser, studyOrg);
                        // orgHelperUserNew.StudyOrganization = studyOrg;
                        _dbContext.UserOrganizations.Add(orgHelperUserNew);
                    }
                #endregion
            #endregion

            _dbContext.SaveChanges();
        }
    }
}