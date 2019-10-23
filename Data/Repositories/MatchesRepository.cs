using FootballLeague.Data.Repositories.Interfaces;
using FootballLeague.Models;
using System.Data.Entity;
using System.Linq;

namespace FootballLeague.Data.Repositories
{
    public class MatchesRepository : IMatchesRepository<Match>
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Delete(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
            db.SaveChanges();
        }

        public void Insert(Match entity)
        {
            db.Matches.Add(entity);
            db.SaveChanges();
        }

        public void Update(Match entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();

        }

        public IQueryable<Match> GetAll() => db.Matches.Include(m => m.HomeTeam).Include(m => m.AwayTeam);


        public Match GetById(int id) => db.Matches.Find(id);

        public IQueryable<Match> GetTeamMatches (int teamId)
        {
            return db.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Where(m => m.IsOver && m.HomeTeamId == teamId || m.AwayTeamId == teamId);
        }
    }
}