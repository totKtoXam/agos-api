using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace agos_api.Models.Base
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
             optionsBuilder.EnableSensitiveDataLogging();
         }
            
   
        public DbSet<Group> Groups { get; set; }
        public DbSet<Otdel> Otdels { get; set; }
        public DbSet<Speciality> Specialitys { get; set; }
        public DbSet<SpecialityOtdel> SpecialityOtdels { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}