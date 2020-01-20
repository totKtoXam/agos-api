using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using agos_api.Models.Users;
using agos_api.Models.Organizations;
using agos_api.Models.UsersOrg;
using agos_api.Models.StaticData;


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
        }
            
   
        #region USERS
            public DbSet<Teacher> Teachers { get; set; }
            public DbSet<devUser> devUsers { get; set; }
            public DbSet<RefreshToken> RefreshTokens { get; set; }
        #endregion

        #region Organizations
            public DbSet<UserOrganization> UserOrganizations { get; set; }
            public DbSet<Classroom> Classrooms { get; set; } 
            public DbSet<ClassroomOfTeacher> ClassroomOfTeachers { get; set; }
            public DbSet<Group> Groups { get; set; }
            public DbSet<Otdel> Otdels { get; set; }
            public DbSet<Semestr> Semestrs { get; set; }
            public DbSet<StudyOrganization> StudyOrganizations { get; set; }
            public DbSet <TeachDiscip> TeachDiscips { get; set; }  
        #endregion
        
        #region Schedule
            public DbSet<AcademicPlan> AcademicPlans { get; set; }
            public DbSet<DayOfWeek> DayOfWeeks { get; set; }

        #endregion
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<DisciplineSpecial> DisciplineSpecials { get; set; }
        public DbSet<HolidayCalendar> HolidayCalendars { get; set; }
        public DbSet<Speciality> Specialitys { get; set; }
        public DbSet<SpecialityOtdel> SpecialityOtdels { get; set; }
<<<<<<< HEAD
        public DbSet<TypeLesson> TypeLessons { get; set; }
        public DbSet<TypeWeek> TypeWeeks { get; set; }
=======
        public DbSet<WeekDay> WeekDays { get; set; }
>>>>>>> 99b59f264104b552c0c4b387a43d6e3b85d42cdd
    }
}