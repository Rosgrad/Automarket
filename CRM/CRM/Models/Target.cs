using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class Target
    {
        public int Id { get; set; }
        public string task { get; set; }
        public string executor { get; set; }
        public DateTime timestart { get; set; }
        public string timecom { get; set; }
        public decimal fine { get; set; }
        public DateTime timeend { get; set; }
        public string coment { get; set; }
    }
}