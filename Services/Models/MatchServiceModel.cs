using FootballLeague.Models;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Services.Models
{
    public class MatchServiceModel
    {
        public int Id { get; set; }

        [Required]
        public int HomeTeamId { get; set; }
        
        public Team HomeTeam { get; set; }
        
        [Required]
        public int AwayTeamId { get; set; }
               
        public Team AwayTeam { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public bool IsOver { get; set; }
    }
}