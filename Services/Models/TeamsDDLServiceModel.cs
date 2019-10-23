using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballLeague.Services.Models
{
    public class TeamsDDLServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; internal set; }
    }
}