using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace CRM.Models
    
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class OtchetDB:DbContext
    {
        public OtchetDB() : base("zenit")
        {
 

        }
        public virtual DbSet<Othet> Othets { get; set; }
       // public virtual DbSet<Kas> Kasses { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }  
    }
}