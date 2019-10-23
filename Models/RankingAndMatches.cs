using FootballLeague.Services.Models;
using System.Collections.Generic;

namespace FootballLeague.Models
{
    public class RankingAndMatches
    {
        public RankingAndMatches()
        {
            TeamsPlayedMatches = new List<Match>();
            TeamsRanking = new List<TeamsDDLServiceModel>();
        }
        public List<TeamsDDLServiceModel> TeamsRanking { get; set; }
        public List<Match> TeamsPlayedMatches { get; set; }
    }
}