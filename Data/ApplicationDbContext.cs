using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FootballLeague.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
             : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }


    }
}