using System;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Models
{
    public class Team
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public int  Points { get; set; }

        public DateTime CreatedTime { get; set; }

        public bool IsDeleted { get; set; }

    }
}