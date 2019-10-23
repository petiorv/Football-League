using System.Collections.Generic;
using System.Linq;
using FootballLeague.Data.Repositories.Interfaces;
using FootballLeague.Models;
using FootballLeague.Models.Interfaces;
using FootballLeague.Services.Models;

namespace FootballLeague.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly ITeamsRepository<Team> _teamsRepository;

        public TeamsService(ITeamsRepository<Team> teamsRepository)
        {
            _teamsRepository = teamsRepository;
        }
        
        public IEnumerable<TeamServiceModel> GetRankedTeams()
        {
            return this._teamsRepository
                .GetAll()
                .Select(x => new TeamServiceModel
                {
                    Name = x.Name,
                    Points = x.Points
                })
                .OrderByDescending(t => t.Points);
        }
    }
}