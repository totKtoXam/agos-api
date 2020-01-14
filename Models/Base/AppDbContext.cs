using Microsoft.EntityFrameworkCore;

namespace agos_api.Models.Base
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
             optionsBuilder.EnableSensitiveDataLogging();
         }
            
   
        public DbSet<Speciality> Specialitys { get; set; }
        public DbSet<Otdel> Otdels { get; set; }
    }
}