using System.Collections.Generic;
using System.Linq;
using FootballLeague.Data.Repositories;
using FootballLeague.Data.Repositories.Interfaces;
using FootballLeague.Models;
using FootballLeague.Services.Interfaces;
using FootballLeague.Services.Models;

namespace FootballLeague.Services
{
    public class MatchesService : IMatchesService
    {
        private IMatchesRepository<Match> _matchesRepository;
        private ITeamsRepository<Team> _teamsRepository;

        public MatchesService(IMatchesRepository<Match> matchesRepository, ITeamsRepository<Team> teamsRepository)
        {
            this._teamsRepository = teamsRepository;
            this._matchesRepository = matchesRepository;
        }   

        public IEnumerable<MatchServiceModel> GetAll()
        {
            return this._matchesRepository
                .GetAll()
                .Select(x => new MatchServiceModel
                {
                    Id = x.Id,
                    HomeTeam = x.HomeTeam,
                    HomeGoals = x.HomeGoals,
                    AwayTeam = x.AwayTeam,
                    AwayGoals = x.AwayGoals,
                    IsOver = x.IsOver
                });
        }

        public IEnumerable<Match> GetCurrentTeamMatches(int teamId)
        {
            return this._matchesRepository.GetTeamMatches(teamId);
        }

        public IEnumerable<TeamsDDLServiceModel> GetTeams()
        {
            return this._teamsRepository.GetAll().Where(t => t.IsDeleted == false).Select(t => new TeamsDDLServiceModel
            {
                Id = t.Id,
                Name = t.Name,
                Points = t.Points
            });
        }


        public void UpdatePoints(Match match)
        {
            if (match.HomeGoals > match.AwayGoals)
            {
                SavePoints(match.HomeTeamId, Scoring.Win);
            }
            else if (match.AwayGoals > match.HomeGoals)
            {
                SavePoints(match.AwayTeamId, Scoring.Win);
            }
            else
            {
                SavePoints(match.AwayTeamId, Scoring.Draw);
                SavePoints(match.HomeTeamId, Scoring.Draw);
            }
        }

        private void SavePoints(int id, Scoring score)
        {
            Team team = this._teamsRepository.GetById(id);
            team.Points += (int)score;

            this._teamsRepository.Update(team);
        }
    }
}