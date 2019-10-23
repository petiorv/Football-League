using System;

namespace FootballLeague.Services.Models
{
    public class TeamServiceModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}