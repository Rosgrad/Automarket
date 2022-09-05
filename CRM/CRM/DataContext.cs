using CRM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace CRM
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {


        }
        public DbSet<Target> Targets { get; set; }

    }
}