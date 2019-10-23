using FootballLeague.Models;
using FootballLeague.Services.Models;
using System.Collections;
using System.Collections.Generic;

namespace FootballLeague.Services.Interfaces
{
    public interface IMatchesService
    {
        IEnumerable<Match> GetCurrentTeamMatches (int id);

        IEnumerable<MatchServiceModel> GetAll();

        void UpdatePoints(Match match);

        IEnumerable<TeamsDDLServiceModel> GetTeams();

    }
}
