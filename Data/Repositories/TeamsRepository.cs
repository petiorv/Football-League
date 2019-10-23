using System.Data.Entity;
using System.Linq;
using FootballLeague.Data.Repositories.Interfaces;
using FootballLeague.Models;

namespace FootballLeague.Data.Repositories
{
    public class TeamsRepository : ITeamsRepository<Team>
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Delete(int id)
        {
            Team team = db.Teams.Find(id);

            var matches = db.Matches
                .Where(m => m.HomeTeamId == id || m.AwayTeamId == id)
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam);

            db.Matches.RemoveRange(matches);
            
            db.Teams.Remove(team);
            db.SaveChanges();
        }

        public void Insert(Team entity)
        {
            db.Teams.Add(entity);
            db.SaveChanges();
        }

        public void Update(Team entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();

        }

        public IQueryable<Team> GetAll() => db.Teams;


        public Team GetById(int id) => db.Teams.Find(id);

    }
}