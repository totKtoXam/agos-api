using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using agos_api.Models.Users;
using agos_api.Models.Organizations;
using agos_api.Models.UsersOrg;


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
        #endregion

        #region Organizations
            public DbSet<StudyOrganization> StudyOrganizations { get; set; }
            public DbSet<Group> Groups { get; set; }
            public DbSet<Otdel> Otdels { get; set; }
            public DbSet<UserOrganization> UserOrganizations { get; set; }
        #endregion
        
        public DbSet<Speciality> Specialitys { get; set; }
        public DbSet<SpecialityOtdel> SpecialityOtdels { get; set; }
    }
}