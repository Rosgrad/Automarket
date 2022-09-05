using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Models
{
    [Table("Player")]
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }

    [Table("Team")]
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } // название команды
        public string Coach { get; set; } // тренер

        public ICollection<Player> Players { get; set; }

    }

}