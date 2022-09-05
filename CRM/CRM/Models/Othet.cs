using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Models
{
    [Table("Othet")]
    public class Othet
    { 
        public int Id { get; set; }
        public Nullable <DateTime>  Time { get; set; }  
        public  int Tabn { get; set; }
        public decimal Prixod { get; set; } 
        public decimal Rasxod { get; set; } 
        public int Id_podr { get; set; } 
        public char Comment { get; set; }   
        public char Emp { get; set; }
        public Nullable<DateTime> Timew   { get; set; }
        public int Nomer_oper { get; set; }
        public int IdKass { get; set; }
       // public Kas Kass { get; set; }
    }
    

    [Table("Kass")]
    public class Kas
    {
        public int Id { get; set; }
        public int Kassid { get; set; } 
        public string Kass_name {get; set; }
        public string Kass_adres { get; set; }
        public char Kass_buk { get; set; }

        public ICollection<Othet>Othetes { get; set; }


    }
}