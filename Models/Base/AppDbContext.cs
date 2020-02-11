using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using agos_api.Models.Users;
using agos_api.Models.Organizations;
using agos_api.Models.Organizations.PersonOrg;
using agos_api.Models.StaticData;
using agos_api.Models.Schedule;
using agos_api.Models.Studying;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace agos_api.Models.Base
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.Entity<WeekDay>()
            //     .Property(b => b.FullDayName)
            //     .HasConversion(
            //             v => JsonConvert.SerializeObject(v),
            //             v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v)
            //     );

            // builder.Entity<WeekDay>()
            //     .Property(b => b.ShortDayName)
            //     .HasConversion(
            //             v => JsonConvert.SerializeObject(v),
            //             v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v)
            //     );
            
            // builder.Entity<TypeLesson>()
            //     .Property(b => b.TypeLessonName)
            //     .HasConversion(
            //             v => JsonConvert.SerializeObject(v),
            //             v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v)
            //     );

            // builder.Entity<TypeWeek>()
            //     .Property(b => b.TypeWeekName)
            //     .HasConversion(
            //             v => JsonConvert.SerializeObject(v),
            //             v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v)
            //     );
        }
            
   
        #region USERS
            public DbSet<Teacher> Teachers { get; set; }
            public DbSet<DevUser> DevUsers { get; set; }
        #endregion

        #region Organizations
            public DbSet<UserOrganization> UserOrganizations { get; set; }
            public DbSet<Classroom> Classrooms { get; set; } 
            public DbSet<ClassroomOfTeacher> ClassroomOfTeachers { get; set; }
            public DbSet<Group> Groups { get; set; }
            public DbSet<Speciality> Specialitys { get; set; }
            public DbSet<Semestr> Semestrs { get; set; }
            public DbSet<StudyOrganization> StudyOrganizations { get; set; }
            public DbSet <TeachDiscip> TeachDiscips { get; set; } 
            public DbSet <RepresentativeOrganization> RepresentativeOrganizations { get; set; }
        #endregion
        
        #region Schedule
            public DbSet<AcademicPlan> AcademicPlans { get; set; }
        #endregion
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<DisciplineSpecial> DisciplineSpecials { get; set; }
        public DbSet<HolidayCalendar> HolidayCalendars { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        // public DbSet<ClassificationSpeciality> ClassificationSpecialitys { get; set; }
        public DbSet<TypeLesson> TypeLessons { get; set; }
        public DbSet<TypeWeek> TypeWeeks { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }
    }
}