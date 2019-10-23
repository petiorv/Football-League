using FootballLeague.Services.Models;
using System.Collections.Generic;

namespace FootballLeague.Models.Interfaces
{
    public interface ITeamsService
    {       
        IEnumerable<TeamServiceModel> GetRankedTeams();        
    }
}
